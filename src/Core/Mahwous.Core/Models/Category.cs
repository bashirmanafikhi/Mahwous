using System.Collections.Generic;

namespace Mahwous.Core.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; }

        public string CoverPath { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;

        public virtual IList<Status> Statuses { get; set; }
    }
}
