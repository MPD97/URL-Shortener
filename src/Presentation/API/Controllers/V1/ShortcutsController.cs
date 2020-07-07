using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ShortcutsController : Controller
    {
        private readonly IShortcutQuery _shortcutQuery;
        private readonly IAliasGenerator _generator;
        private readonly IShortcutAdmin _shortcutAdmin;
        private readonly IRedirectQuery _redirectQuery;
        private readonly IRedirectExtendedQuery _redirectExtendedQuery;

        public ShortcutsController(IShortcutQuery shortcutQuery, IAliasGenerator generator, IShortcutAdmin shortcutAdmin,
            IRedirectQuery redirectQuery, IRedirectExtendedQuery redirectExtendedQuery)
        {
            _shortcutQuery = shortcutQuery;
            _generator = generator;
            _shortcutAdmin = shortcutAdmin;
            _redirectQuery = redirectQuery;
            _redirectExtendedQuery = redirectExtendedQuery;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll(int? skip = null, int? take = null)
        {
            List<Shortcut> result = null;
            if (skip.HasValue && take.HasValue)
            {
                result = await _shortcutQuery.All(take.Value, skip.Value);
            }
            else
            {
                result = await _shortcutQuery.All();
            }


            return Ok(result.Select(shortcut => new ShortcutGetResponse
            {
                Alias = shortcut.Alias,
                Url = shortcut.RedirectExtended != null ? shortcut.RedirectExtended.Url : shortcut.Redirect.Url,
                ShortcutId = shortcut.ShortcutId,
                TimesRedirect = shortcut.TimesRedirect
            }));
        }
        [HttpGet("Amount")]
        public async Task<IActionResult> Amount()
        {
            return Ok(await _shortcutQuery.Count());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _shortcutQuery.Find(id, true);
            if (result == null)
            {
                return BadRequest("Shortcut with this id not exists.");
            }

            return Ok(new ShortcutGetResponse
            {
                Alias = result.Alias,
                Url = result.RedirectExtended != null ? result.RedirectExtended.Url : result.Redirect.Url,
                ShortcutId = result.ShortcutId,
                TimesRedirect = result.TimesRedirect
            });
        }

        [HttpPost()]
        public async Task<IActionResult> Create(ShortcutCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ValidationError");
            }

            var validUrl = Uri.TryCreate(request.Url, UriKind.Absolute, out var uriResult)
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
            var shortcut = await _shortcutQuery.Find(alias, true);
            if (shortcut == null)
            {
                return BadRequest("Shortcut with this alias not exists.");
            }

            shortcut = await _shortcutAdmin.IncreaseRedirectCount(shortcut);
            if (await _shortcutAdmin.SaveChangesAsync() <= 0)
            {
                return StatusCode(500, "Error");
            }

            if (shortcut.Redirect != null)
            {
                return Redirect(shortcut.Redirect.Url);
            }

            if (shortcut.RedirectExtended != null)
            {
                return Redirect(shortcut.RedirectExtended.Url);
            }

            return StatusCode(500, "Error");
        }
    }
}