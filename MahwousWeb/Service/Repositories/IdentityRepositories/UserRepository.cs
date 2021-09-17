using MahwousWeb.Models.Models;
using MahwousWeb.Models.Pagination;
using MahwousWeb.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/users";

        public UserRepository(HttpClient httpClient)
        {
            this.httpService = new HttpService(httpClient);
        }

        public async Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDetails paginationDTO)
        {
            return await httpService.GetHelper<List<UserDTO>>(url, paginationDTO);
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await httpService.GetHelper<List<RoleDTO>>($"{url}/roles");
        }

        public async Task AssignRole(EditRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/assignRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task RemoveRole(EditRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/removeRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }



    }
}