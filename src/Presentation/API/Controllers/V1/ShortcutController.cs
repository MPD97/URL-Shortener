using System.Threading.Tasks;
using Core.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using Presistance.Services;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShortcutController : Controller
    {
        private readonly IShortcutQuery _shortcutQuery;

        public ShortcutController(IShortcutQuery shortcutQuery)
        {
            _shortcutQuery = shortcutQuery;
        }

        [HttpGet("/{id}")]
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
            return Ok();
        }
    }
}