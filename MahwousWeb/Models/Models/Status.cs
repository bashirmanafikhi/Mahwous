using System.Collections.Generic;

namespace MahwousWeb.Models.Models
{
    public abstract class Status : ModelBase
    {
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }
        public int SharesCount { get; set; }


        // [Ignore] // this attribute for sqlite in xamarin
        public IList<StatusCategories> StatusCategories { get; set; }

    }
}
