using MahwousWeb.Shared.Models;
using System.Linq;


namespace MahwousWeb.Shared.Filters
{
    public class ImageFilter : StatusFilter, IFilter<ImageStatus>
    {

        public IQueryable<ImageStatus> Filter(IQueryable<ImageStatus> queryable)
        {
            queryable = base.Filter(queryable).Cast<ImageStatus>();

            return queryable;
        }
    }
}
