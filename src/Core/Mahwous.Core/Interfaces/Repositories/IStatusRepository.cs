using Mahwous.Core.Entities;

namespace Mahwous.Core.Interfaces.Repositories
{
    public interface IStatusRepository<T> : IEntityRepository<T> where T : Status
    {

    }
}
