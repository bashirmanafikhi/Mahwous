using Mahwous.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahwous.Application.Interfaces
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
