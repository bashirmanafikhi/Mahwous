using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous.Core.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }
        public int RoomId { get; set; }
        public virtual ChatRoom Room { get; set; }

        public int? ReplyToId { get; set; }
        public virtual Message ReplyTo { get; set; }
    }
}
