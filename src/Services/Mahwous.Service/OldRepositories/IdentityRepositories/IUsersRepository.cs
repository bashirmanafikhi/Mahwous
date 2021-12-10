using Mahwous.Core.Dtos;
using Mahwous.Core.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahwous.Service.Repositories
{
    public interface IUsersRepository
    {
        Task AssignRole(ChangeRoleDTO editRole);
        Task<List<RoleDTO>> GetRoles();
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDetails pagination);
        Task RemoveRole(ChangeRoleDTO editRole);
    }
}
