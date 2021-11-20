using Mahwous.Core.Filters;
using Mahwous.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Mahwous.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string CoverPath { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;

        // Virtuals
        public virtual IList<Status> Statuses { get; set; }

        // Get Properties
        public new Type FilterType => typeof(CategoryFilter);
    }
}
