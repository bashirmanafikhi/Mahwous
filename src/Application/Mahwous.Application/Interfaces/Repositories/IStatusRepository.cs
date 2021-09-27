using Mahwous.Core.Models;

namespace Mahwous.Application.Interfaces.Repositories
{
    public interface IStatusRepository<T> : IRepository<T> where T : Status
    {

    }
}
