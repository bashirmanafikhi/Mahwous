using Mahwous.Core.Dtos;
using System.Threading.Tasks;

namespace Mahwous.UI.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken userToken);
        Task Logout();
    }
}
