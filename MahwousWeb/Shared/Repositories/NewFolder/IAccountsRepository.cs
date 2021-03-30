using MahwousWeb.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Shared.Repositories
{
    public interface IAccountsRepository
    {
        Task<UserToken> Login(UserInfo userInfo);
        Task<UserToken> Register(RegisterUserInfo userInfo);
        //Task<UserToken> RenewToken();
    }
}
