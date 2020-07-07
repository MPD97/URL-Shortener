using System.Threading.Tasks;
using Core.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ShortcutController : Controller
    {
        [HttpPost()]
        public async Task<IActionResult> Create(ShortcutCreateRequest request)
        {
            return View();
        }
    }
}