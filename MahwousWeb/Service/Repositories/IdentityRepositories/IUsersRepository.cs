using Mahwous.Core.Dtos;
using MahwousWeb.Models.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public interface IUsersRepository
    {
        Task AssignRole(EditRoleDTO editRole);
        Task<List<RoleDTO>> GetRoles();
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDetails paginationDTO);
        Task RemoveRole(EditRoleDTO editRole);
    }
}
