//using Mahwous.Core.Dtos;
//using Mahwous.Persistence.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Mahwous.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AccountsController : ControllerBase
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly IConfiguration _configuration;

//        public AccountsController(
//            UserManager<ApplicationUser> userManager,
//            SignInManager<ApplicationUser> signInManager,
//            IConfiguration configuration)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            _configuration = configuration;
//        }



//        [HttpPost("Register")]
//        public async Task<ActionResult<UserToken>> RegisterUser([FromBody] RegisterUserInfo model)
//        {
//            if (model == null)
//                return BadRequest("Register Model is null");

//            if (model.Password != model.ConfirmPassword)
//                return BadRequest("Confirm password doesn't match the password");


//            var user = new ApplicationUser
//            {
//                Email = model.Email,
//                UserName = model.Email
//            };


//            var result = await _userManager.CreateAsync(user, model.Password);

//            if (result.Succeeded)
//            {
//                return await BuildToken(model);
//            }
//            else
//            {
//                return BadRequest(result.Errors.Select(e => e.Description));
//            }
//        }


//        [HttpPost("Login")]
//        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
//        {
//            var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
//                userInfo.Password, isPersistent: false, lockoutOnFailure: false);

//            if (result.Succeeded)
//            {
//                return await BuildToken(userInfo);
//            }
//            else
//            {
//                return BadRequest("Invalid login attempt");
//            }
//        }


//        private async Task<UserToken> BuildToken(UserInfo userinfo)
//        {

//            var identityUser = await _userManager.FindByEmailAsync(userinfo.Email);


//            var claims = new List<Claim>()
//            {
//                new Claim(ClaimTypes.Name, identityUser.FirstName ?? identityUser.Email),
//                new Claim(ClaimTypes.Email, identityUser.Email),
//                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
//            };

//            var claimsDB = await _userManager.GetClaimsAsync(identityUser);
//            claims.AddRange(claimsDB);


//            var roles = await _userManager.GetRolesAsync(identityUser);
//            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));



//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var expiration = DateTime.UtcNow.AddYears(1);

//            JwtSecurityToken token = new JwtSecurityToken(
//               issuer: _configuration["JwtSettings:Issuer"],
//               audience: _configuration["JwtSettings:Audience"],
//               claims: claims,
//               expires: expiration,
//               signingCredentials: creds);

//            return new UserToken()
//            {
//                Token = new JwtSecurityTokenHandler().WriteToken(token),
//                Expiration = expiration
//            };
//        }
//    }
//}
