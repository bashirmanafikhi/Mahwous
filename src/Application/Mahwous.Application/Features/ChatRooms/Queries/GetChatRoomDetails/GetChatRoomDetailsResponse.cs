using Mahwous.Application.Mappings;
using Mahwous.Core.Entities;
using System;
using System.Collections.Generic;

namespace Mahwous.Application.Features.ChatRooms
{
    public class GetChatRoomDetailsResponse : IMapFrom<ChatRoom>
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverPath { get; set; }
    }
}
