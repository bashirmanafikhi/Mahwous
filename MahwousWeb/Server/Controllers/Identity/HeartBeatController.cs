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
        public IActionResult Get(string request)
        {
            return Ok(request);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string request)
        {
            return Ok(request);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Authorize([FromBody] string request)
        {
            return Ok(request);
        }

    }
}
