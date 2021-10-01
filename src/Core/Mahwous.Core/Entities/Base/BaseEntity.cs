using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool Visible { get; set; }
        public int ViewsCount { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedById { get; set; }
        public bool IsDeleted { get; set; }


        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            Visible = true;
        }



        // Get Properties
        public Type FilterType => typeof(EntityFilter<BaseEntity>);
    }
}
