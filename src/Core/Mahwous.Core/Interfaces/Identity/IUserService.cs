using Mahwous.Core.Dtos;
using Mahwous.Core.Entities;
using Mahwous.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Core.Interfaces.Identity
{
    public interface IUserService
    {
        Task<UserDTO> GetCurrentUser();
        Task<List<UserDTO>> SearchAsync(PaginationDetails paginationDTO);
    }
}
