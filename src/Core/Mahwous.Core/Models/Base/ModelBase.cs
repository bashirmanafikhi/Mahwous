using System;

namespace Mahwous.Core.Models
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public bool Visible { get; set; }
        public int ViewsCount { get; set; }

        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? LastModifiedById { get; set; }


        public ModelBase()
        {
            CreatedDate = DateTime.Now;
            Visible = true;
        }
    }
}
