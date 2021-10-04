//using Mahwous.Core.Dtos;
//using Mahwous.Core.Pagination;
//using Mahwous.API.Helpers;
//using MahwousWeb.Persistent;
//using MahwousWeb.Persistent.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Mahwous.Core.Extentions;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Mahwous.API.Controllers.Identity
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    [Authorize(Roles = "مدير")]
//    public class UsersController : ControllerBase
//    {
//        private readonly ApplicationDbContext context;
//        private readonly UserManager<ApplicationUser> userManager;

//        public UsersController(ApplicationDbContext context,
//            UserManager<ApplicationUser> userManager)
//        {
//            this.context = context;
//            this.userManager = userManager;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDetails paginationDTO)
//        {
//            var queryable = context.Users.AsQueryable();
//            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO);
//            return await queryable.Paginate(paginationDTO)
//                .Select(x => new UserDTO { Email = x.Email, UserId = x.Id }).ToListAsync();
//        }

//        [HttpGet("roles")]
//        public async Task<ActionResult<List<RoleDTO>>> Get()
//        {
//            return await context.Roles
//                .Select(x => new RoleDTO { RoleName = x.Name }).ToListAsync();
//        }




//        [HttpPost("assignRole")]
//        public async Task<ActionResult> AssignRole(EditRoleDTO model)
//        {
//            var user = await userManager.FindByIdAsync(model.UserId);

//            await userManager.AddToRoleAsync(user, model.RoleName);
//            //await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, model.RoleName));

//            return NoContent();
//        }




//        [HttpPost("removeRole")]
//        public async Task<ActionResult> RemoveRole(EditRoleDTO model)
//        {
//            var user = await userManager.FindByIdAsync(model.UserId);

//            await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, model.RoleName));
//            //await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, model.RoleName));

//            return NoContent();
//        }
//    }
//}
