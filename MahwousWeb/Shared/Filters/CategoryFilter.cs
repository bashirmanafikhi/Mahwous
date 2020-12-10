using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class CategoryFilter : IFilter<Category>
    {

        public PaginationDetails Pagination { get; set; } = new PaginationDetails { RecordsPerPage = 200 };

        public string Name { get; set; }

        public bool ForVideos { get; set; }
        public bool ForImages { get; set; }
        public bool ForQuotes { get; set; }

        public IQueryable<Category> Filter(IQueryable<Category> queryable)
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                queryable = queryable
                    .Where(c => c.Name.Contains(Name));
            }

            if (ForImages)
            {
                queryable = queryable.Where(c => c.ForImages);
            }

            if (ForQuotes)
            {
                queryable = queryable.Where(c => c.ForQuotes);
            }

            if (ForVideos)
            {
                queryable = queryable.Where(c => c.ForVideos);
            }

            return queryable;
        }
    }
}
