using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class ChatRoomRepository : EntityRepository<ChatRoom, ChatRoomFilter>, IChatRoomRepository
    {
        public ChatRoomRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        { }

    }
}
