using Mahwous.Core.Dtos;
using System.Threading.Tasks;

namespace MahwousWeb.Client.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken userToken);
        Task Logout();
    }
}
