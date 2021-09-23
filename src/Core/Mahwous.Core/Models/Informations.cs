using System.Collections.Generic;

namespace Mahwous.Core.Models
{

    public class Informations
    {
        public int Count { get; set; }

        public long LikesCount { get; set; }
        public long DownloadsCount { get; set; }
        public long SharesCount { get; set; }
        public long ViewsCount { get; set; }


        /// <summary>
        /// Dictionary<CategoryName, StatusesCounts>
        /// </summary>
        public Dictionary<string, int> CategoriesStatusCounts { get; set; }
    }
}
