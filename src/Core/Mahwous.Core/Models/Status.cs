using System.Collections.Generic;

namespace Mahwous.Core.Models
{
    public abstract class Status : ModelBase
    {
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }
        public int SharesCount { get; set; }

        public virtual IList<Category> Categories { get; set; }
    }
}
