using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class CategoryFilter : EntityFilter<Category>
    {
        public string Name { get; set; }

        public bool ForVideos { get; set; }
        public bool ForImages { get; set; }
        public bool ForQuotes { get; set; }

        public override IQueryable<Category> FilterOtherEntityProperties(IQueryable<Category> queryable)
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
