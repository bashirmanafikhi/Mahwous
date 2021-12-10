using Mahwous.Core.Dtos;
using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mahwous.Core.Interfaces.Identity
{
    public interface IAccountService
    {
        Task<UserToken> RegisterUser(RegisterUserInfo model);
        Task<UserToken> Login(UserInfo userInfo);
    }
}
