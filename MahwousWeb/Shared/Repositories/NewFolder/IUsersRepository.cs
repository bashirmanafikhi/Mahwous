using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories
{
    public interface IUsersRepository
    {
        Task AssignRole(EditRoleDTO editRole);
        Task<List<RoleDTO>> GetRoles();
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDetails paginationDTO);
        Task RemoveRole(EditRoleDTO editRole);
    }
}
