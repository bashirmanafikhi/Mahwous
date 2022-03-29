using Mahwous.Core.Dtos;
using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Pagination;
using Mahwous.Persistence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Mahwous.Core.Extentions;
using Microsoft.AspNetCore.Authentication;

namespace Mahwous.Persistence.IdentityServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor accessor;
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(ApplicationDbContext context,
            IHttpContextAccessor accessor, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.accessor = accessor;
            this.userManager = userManager;
        }

        public async Task<UserDTO> GetCurrentUser()
        {
            ClaimsPrincipal currentUser = accessor.HttpContext?.User;
            string userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string userEmail = currentUser.FindFirst(ClaimTypes.Email)?.Value;
            string name = currentUser.FindFirst(ClaimTypes.Name)?.Value;

            // How to get application user
            //ApplicationUser user = await userManager.GetUserAsync(currentUser);

            return new UserDTO()
            {
                Id = userId,
                Email = userEmail,
                Name = name
            };
        }

        public async Task<PaginatedList<UserDTO>> SearchAsync(PaginationDetails paginationDTO)
        {
            var queryable = context.Users.AsQueryable();
            var totalCount = await queryable.CountAsync();
            var list = await queryable.Paginate(paginationDTO)
                .Select(x => new UserDTO { Email = x.Email, Id = x.Id, Name = x.FirstName + x.LastName }).ToListAsync();

            return new PaginatedList<UserDTO>(list, totalCount, paginationDTO);
        }
    }
}
