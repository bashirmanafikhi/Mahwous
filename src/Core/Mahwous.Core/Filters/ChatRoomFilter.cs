using Mahwous.Core.Entities;
using System.Linq;

namespace Mahwous.Core.Filters
{
    public class ChatRoomFilter : EntityFilter<ChatRoom>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override IQueryable<ChatRoom> FilterOtherEntityProperties(IQueryable<ChatRoom> queryable)
        {
            if (!string.IsNullOrEmpty(Name))
                queryable = queryable.Where(x => x.Name.Contains(Name));

            if (!string.IsNullOrEmpty(Description))
                queryable = queryable.Where(x => x.Description.Contains(Description));

            return queryable;
        }
    }
}
