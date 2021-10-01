using Mahwous.Core.Filters;
using System;
using System.Collections.Generic;

namespace Mahwous.Core.Entities
{
    public abstract class Status : BaseEntity
    {
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }
        public int SharesCount { get; set; }

        public virtual IList<Category> Categories { get; set; }

        // Get Properties
        public new Type FilterType => typeof(StatusFilter<Status>);
    }
}
