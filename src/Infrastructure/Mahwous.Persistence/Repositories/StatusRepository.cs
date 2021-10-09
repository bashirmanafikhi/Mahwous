using Mahwous.Core.Entities;
using Mahwous.Core.Enums;
using Mahwous.Core.Extentions;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;
using Mahwous.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MahwousWeb.Persistent.Repositories
{
    public class StatusRepository<T, F> : EntityRepository<T, F>, IStatusRepository<T, F>
        where T : Status
        where F : StatusFilter<T>
    {
        public StatusRepository(ApplicationDbContext context) : base(context)
        { 
        
        }

        public async Task<PaginatedList<T>> SearchAsync(F filter, PaginationDetails pagination, StatusSortType sortType)
        {
            var query = _context.Set<T>().AsNoTracking();

            var filteredQuery = query.Filter(filter);

            var totalCount = filteredQuery.Count();

            var sortedQuery = filteredQuery.Sort(sortType);

            var paginatedQuery = sortedQuery.Paginate(pagination);

            var list = await paginatedQuery.ToListAsync();

            var paginatedList = new PaginatedList<T>(list, totalCount, pagination);

            return paginatedList;
            //o r m
        }
    }
}
