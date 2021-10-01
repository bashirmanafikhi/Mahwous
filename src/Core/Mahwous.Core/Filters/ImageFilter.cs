using Mahwous.Core.Entities;
using System.Linq;


namespace Mahwous.Core.Filters
{
    public class ImageFilter : StatusFilter<ImageStatus>
    {

        public override IQueryable<ImageStatus> FilterOtherStatusProperties(IQueryable<ImageStatus> queryable)
        {


            return queryable;
        }
    }
}
