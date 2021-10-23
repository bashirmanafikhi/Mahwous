using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Extentions;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces;
using Mahwous.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mahwous.Persistence.Repositories
{
    public partial class EntityRepository<T, F> : IEntityRepository<T, F>
        where T : BaseEntity
        where F : EntityFilter<T>
    {
        protected readonly ApplicationDbContext _context;

        public EntityRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public async Task<T> GetRandomAsync()
        {
            return await _context.Set<T>().AsNoTracking().OrderBy(v => Guid.NewGuid()).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstAsync(x => x.Id == id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<T>> SearchAsync(F filter, PaginationDetails pagination, EntitySortType sortType)
        {
            var query = _context.Set<T>().AsNoTracking();

            var filteredQuery = query.Filter(filter);

            var totalCount = filteredQuery.Count();

            var sortedQuery = filteredQuery.Sort(sortType);

            var paginatedQuery = sortedQuery.Paginate(pagination);

            var list = await paginatedQuery.ToListAsync();

            var paginatedList = new PaginatedList<T>(list, totalCount, pagination);

            return paginatedList;
        }

        public async Task<List<T>> ListAllAsync(F filter)
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .Filter(filter)
                                 .ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }
    }
}
