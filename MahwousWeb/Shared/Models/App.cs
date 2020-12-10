using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Shared.Models
{
    public class App : ModelBase
    {
        public string Package { get; set; }
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string PlayStoreLink { get; set; }

        [DataType(DataType.Url)]
        public string AppleStoreLink { get; set; }



        public int PlayStoreOpenedCount { get; set; }
        public int AppleStoreOpenedCount { get; set; }


        public IList<NotificationApps> NotificationApps { get; set; }
    }
}
