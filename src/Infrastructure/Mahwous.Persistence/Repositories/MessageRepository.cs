﻿using Mahwous.Core.Entities;
using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Repositories;

namespace Mahwous.Persistence.Repositories
{
    public class MessageRepository : EntityRepository<Message, MessageFilter>, IMessageRepository
    {
        public MessageRepository(ApplicationDbContext context) : base(context)
        { }

    }
}
