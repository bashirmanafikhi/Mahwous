using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers.Identity
{
    [Route("api/[controller]/[action]")]
    public class HeartBeatController : Controller
    {

        public HeartBeatController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Check(string request)
        {
            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> CheckPost([FromBody] string request)
        {
            return Ok(request);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CheckAuthorize([FromBody] string request)
        {
            return Ok(request);
        }

    }
}
