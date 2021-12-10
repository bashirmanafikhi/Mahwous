using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class MessageFilter : EntityFilter<Message>
    {
        public string Content { get; set; }
        public int? RoomId { get; set; }


        public override IQueryable<Message> FilterOtherEntityProperties(IQueryable<Message> queryable)
        {
            if (!string.IsNullOrWhiteSpace(Content))
                queryable = queryable.Where(v => v.Content.Contains(Content));

            if(RoomId != null)
                queryable = queryable.Where(v => v.RoomId == RoomId);


            return queryable;
        }
    }
}
