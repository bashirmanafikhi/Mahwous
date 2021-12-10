
using System;
using System.Collections.Generic;

namespace Mahwous.Core.Entities
{
    public class ChatRoom : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverPath { get; set; }

        public IList<Message> Messages{ get; set; }
    }
}
