using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces.Identity;
using System;

namespace Mahwous.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsHidden { get; set; }
        public int ViewsCount { get; set; }

        public string UserId { get; set; }
        public virtual IUser User { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
