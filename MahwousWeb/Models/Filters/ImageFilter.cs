using MahwousWeb.Models.Models;
using System.Linq;


namespace MahwousWeb.Models.Filters
{
    public class ImageFilter : StatusFilterBase<ImageStatus>
    {

        public override IQueryable<ImageStatus> Filter(IQueryable<ImageStatus> queryable)
        {
            queryable = base.Filter(queryable);
            //queryable = base.Filter(queryable).Cast<ImageStatus>();

            return queryable;
        }
    }
}
