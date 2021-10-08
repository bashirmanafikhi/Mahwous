using Mahwous.Core.Entities;
using Mahwous.Core.Filters;

namespace Mahwous.Core.Interfaces.Repositories
{
    public interface IStatusRepository<T, F> : IEntityRepository<T, F>
        where T : Status
        where F : StatusFilter<T>
    {

    }
}
