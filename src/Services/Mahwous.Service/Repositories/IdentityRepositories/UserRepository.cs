using Mahwous.Core.Dtos;
using Mahwous.Core.Pagination;
using Mahwous.Service.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/users";

        public UserRepository(HttpClient httpClient)
        {
            this.httpService = new HttpService(httpClient);
        }

        public async Task<PaginatedList<UserDTO>> GetUsers(PaginationDetails pagination)
        {
            var newUrl = $"{url}?page={pagination.PageIndex}&PageSize={pagination.PageSize}";

            return await httpService.GetHelper<PaginatedList<UserDTO>>(newUrl);
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await httpService.GetHelper<List<RoleDTO>>($"{url}/roles");
        }

        public async Task AssignRole(ChangeRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/assignRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task RemoveRole(ChangeRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/removeRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }



    }
}