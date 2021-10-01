using Mahwous.Core.Dtos;
using System.Threading.Tasks;

namespace MahwousWeb.Service.Repositories
{
    public interface IAccountsRepository
    {
        Task<UserToken> Login(UserInfo userInfo);
        Task<UserToken> Register(RegisterUserInfo userInfo);
        //Task<UserToken> RenewToken();
    }
}
