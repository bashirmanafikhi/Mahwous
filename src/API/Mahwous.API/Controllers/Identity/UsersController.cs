using Mahwous.Core.Dtos;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Pagination;
using Mahwous.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahwous.API.Controllers.Identity
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "مدير")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IRoleService roleService;
        private readonly IUserService userService;

        public UsersController(ApplicationDbContext context,
            IRoleService roleService,
            IUserService userService)
        {
            this.context = context;
            this.roleService = roleService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<UserDTO>>> Get([FromQuery] PaginationDetails paginationDTO)
        {
            return await userService.SearchAsync(paginationDTO);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get()
        {
            return await roleService.ListAllAsync();
        }


        [HttpPost("assignRole")]
        public async Task<ActionResult> AssignRole(ChangeRoleDTO model)
        {
            await roleService.AddUserToRole(model);
            return NoContent();
        }


        [HttpPost("removeRole")]
        public async Task<ActionResult> RemoveRole(ChangeRoleDTO model)
        {
            await roleService.RemoveUserFromRole(model);
            return NoContent();
        }
    }
}
