
using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public class ChatRoom : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverPath { get; set; }
    }
}
