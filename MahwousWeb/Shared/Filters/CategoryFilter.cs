using MahwousWeb.Shared.Models;
using MahwousWeb.Shared.Pagination;
using System.Linq;

namespace MahwousWeb.Shared.Filters
{
    public class CategoryFilter : FilterBase<Category>
    {
        public string Name { get; set; }

        public bool ForVideos { get; set; }
        public bool ForImages { get; set; }
        public bool ForQuotes { get; set; }

        public override IQueryable<Category> Filter(IQueryable<Category> queryable)
        {
            queryable = base.Filter(queryable);

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
