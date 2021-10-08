﻿using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mahwous.Core.Interfaces
{
    public interface IEntityRepository<T, F>
        where T : BaseEntity
        where F : EntityFilter<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetRandomAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAllAsync(F filter);
        Task<PaginatedList<T>> SearchAsync(F filter, PaginationDetails pagination);
    }
}
