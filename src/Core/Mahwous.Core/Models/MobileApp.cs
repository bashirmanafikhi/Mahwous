using System.Collections.Generic;

namespace Mahwous.Core.Models
{
    public class MobileApp : ModelBase
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Package { get; set; }
        public string PlayStoreLink { get; set; }
        public string AppleStoreLink { get; set; }

        public int PlayStoreOpenedCount { get; set; }
        public int AppleStoreOpenedCount { get; set; }

        public IList<Notification> Notifications { get; set; }
    }
}
