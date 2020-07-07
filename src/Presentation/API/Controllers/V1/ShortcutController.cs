using System;
using System.Threading.Tasks;
using Core.DTOs.Requests;
using Core.DTOs.Responses;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Presistance.Repositories;
using Presistance.Services;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShortcutController : Controller
    {
        private readonly IShortcutQuery _shortcutQuery;
        private readonly IAliasGenerator _generator;
        private readonly IShortcutAdmin _shortcutAdmin;
        private readonly IRedirectQuery _redirectQuery;
        private readonly IRedirectExtendedQuery _redirectExtendedQuery;

        public ShortcutController(IShortcutQuery shortcutQuery, IAliasGenerator generator, IShortcutAdmin shortcutAdmin,
            IRedirectQuery redirectQuery, IRedirectExtendedQuery redirectExtendedQuery)
        {
            _shortcutQuery = shortcutQuery;
            _generator = generator;
            _shortcutAdmin = shortcutAdmin;
            _redirectQuery = redirectQuery;
            _redirectExtendedQuery = redirectExtendedQuery;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _shortcutQuery.Find(id);
            if (result == null)
            {
                return BadRequest("Shortcut with this id not exists.");
            }

            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ShortcutCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ValidationError");
            }

            Uri uriResult;
            var validUrl = Uri.TryCreate(request.Url, UriKind.Absolute, out uriResult)
                           && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (!validUrl)
            {
                return BadRequest("Url is not valid url");
            }

            var redirect = await _redirectQuery.Find(request.Url, true);
            if (redirect != null)
            {
                return BadRequest($"This url exist. Use {redirect.Shortcut.Alias}");
            }

            var redirectExtended = await _redirectExtendedQuery.Find(request.Url, true);
            if (redirectExtended != null)
            {
                return BadRequest($"This url exist. Use {redirectExtended.Shortcut.Alias}");
            }

            Shortcut shortcut = null;

            if (!string.IsNullOrEmpty(request.Alias))
            {
                shortcut = await _shortcutQuery.Find(request.Alias);
                if (shortcut != null)
                {
                    return BadRequest("Shortcut with this alias exists.");
                }

                shortcut = await _shortcutAdmin.InsertAsync(request.Alias, request.Url);
            }
            else
            {
                var i = 1;
                var alias = _generator.Generate(i);
                while ((shortcut = await _shortcutQuery.Find(alias)) != null)
                {
                    if (i < 30)
                    {
                        i++;
                    }

                    alias = _generator.Generate(i);
                }

                shortcut = await _shortcutAdmin.InsertAsync(alias, request.Url);
            }

            var result = await _shortcutAdmin.SaveChangesAsync();
            if (result <= 0)
            {
                return StatusCode(500, "Error");
            }

            return StatusCode(201, new ShortcutCreateResponse
            {
                Alias = shortcut.Alias,
                Url = request.Url
            });
        }

        [HttpGet("RedirectTo/{alias}")]
        public async Task<IActionResult> RedirectTo(string alias)
        {
            var result = await _shortcutQuery.Find(alias, true);
            if (result == null)
            {
                return BadRequest("Shortcut with this alias not exists.");
            }

            if (result.Redirect != null)
            {
                return Redirect(result.Redirect.Url);
            }

            if (result.RedirectExtended != null)
            {
                return Redirect(result.RedirectExtended.Url);
            }

            return StatusCode(500, "Error");
        }
    }
}