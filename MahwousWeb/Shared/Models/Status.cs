using SQLite;
using System.Collections.Generic;

namespace MahwousWeb.Shared.Models
{
    public abstract class Status : ModelBase
    {
        //public int ViewsCount { get; set; }
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }
        public int SharesCount { get; set; }


        [Ignore] // this attribute for sqlite in xamarin
        public IList<StatusCategories> StatusCategories { get; set; }

    }
}
