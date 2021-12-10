using Mahwous.Core.Dtos;
using Mahwous.Core.Exceptions;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Persistence.Models;
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

namespace Mahwous.Persistence.IdentityServices
{
    public class RoleService : IRoleService
    {

        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleService(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<List<RoleDTO>> ListAllAsync()
        {
            return await context.Roles
                            .Select(x => new RoleDTO { Name = x.Name }).ToListAsync();
        }

        public async Task AddUserToRole(ChangeRoleDTO model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            await userManager.AddToRoleAsync(user, model.RoleName);
        }

        public async Task RemoveUserFromRole(ChangeRoleDTO model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);
            await userManager.RemoveFromRoleAsync(user, model.RoleName);
        }
    }
}
