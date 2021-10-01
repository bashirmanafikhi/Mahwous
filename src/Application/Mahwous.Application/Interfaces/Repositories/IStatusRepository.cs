using Mahwous.Core.Entities;

namespace Mahwous.Application.Interfaces.Repositories
{
    public interface IStatusRepository<T> : IEntityRepository<T> where T : Status
    {

    }
}
