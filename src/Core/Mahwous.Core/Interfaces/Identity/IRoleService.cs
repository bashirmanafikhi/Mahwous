using Mahwous.Core.Dtos;
using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Core.Interfaces.Identity
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> ListAllAsync();
        Task AddUserToRole(ChangeRoleDTO model);
        Task RemoveUserFromRole(ChangeRoleDTO model);
    }
}
