using Mahwous.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahwous.Application.Interfaces
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
