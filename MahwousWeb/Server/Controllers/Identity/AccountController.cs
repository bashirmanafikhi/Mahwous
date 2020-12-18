
using MahwousWeb.Server.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MahwousWeb.Server.Controllers.Identity
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(InputModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var accessToken1 = Request.Headers[HeaderNames.Authorization];
                    var accessToken2 = await HttpContext.GetTokenAsync("access_token");

                    

                    return accessToken1.ToString();
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }


        void Basir()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];
        }
    }

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
