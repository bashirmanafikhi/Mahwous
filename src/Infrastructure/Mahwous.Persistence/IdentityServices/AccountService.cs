using Mahwous.Core.Dtos;
using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Persistence.IdentityServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }


        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email,
    userInfo.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(userInfo);
            }
            else
            {
                throw new BussinessException("Invalid login attempt");
            }
        }

        public async Task<UserToken> RegisterUser(RegisterUserInfo model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.Password != model.ConfirmPassword)
                throw new BussinessException("Confirm password doesn't match the password");

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return await BuildToken(model);
            }
            else
            {
                throw new BussinessException(result.Errors.Select(e => e.Description));
            }
        }


        private async Task<UserToken> BuildToken(UserInfo userinfo)
        {
            var identityUser = await _userManager.FindByEmailAsync(userinfo.Email);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, identityUser.FirstName ?? identityUser.UserName),
                new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(ClaimTypes.NameIdentifier, identityUser.Id)
            };

            var claimsDB = await _userManager.GetClaimsAsync(identityUser);
            claims.AddRange(claimsDB);

            var userRoles = await _userManager.GetRolesAsync(identityUser);
            var userRolesAsClaims = userRoles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(userRolesAsClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: _configuration["JwtSettings:Issuer"],
               audience: _configuration["JwtSettings:Audience"],
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

    }
}
