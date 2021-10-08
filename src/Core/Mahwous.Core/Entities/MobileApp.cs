using Mahwous.Core.Filters;
using System;
using System.Collections.Generic;

namespace Mahwous.Core.Entities
{
    public class MobileApp : BaseEntity
    {
        public string Name { get; set; }
        public string CoverPath { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public string PlayStoreLink { get; set; }
        public string AppleStoreLink { get; set; }

        public int PlayStoreOpenedCount { get; set; }
        public int AppleStoreOpenedCount { get; set; }

        // Virtuals
        public virtual IList<MobileNotification> Notifications { get; set; }

        // Get Properties
        public new Type FilterType => typeof(MobileAppFilter);
    }
}
