using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using Mahwous.Core.Interfaces.Identity;
using System;

namespace Mahwous.Application.Features.Messages
{
    public class GetMessageDetailsResponse : IMapFrom<Message>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public string Content { get; set; }
        public int RoomId { get; set; }

        //public int? ReplyToId { get; set; }
        //public Message ReplyTo { get; set; }

        public bool IsOwner { get; set; }
        public string OwnerName { get; set; }
    }
}
