using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class FilteredInformations
    {
        public int StatusesCount { get; set; }
        public long LikesCount { get; set; }
        public long DownloadsCount { get; set; }
        public long ViewsCount { get; set; }
        public int CategoriesCount { get; set; }

        /// <summary>
        /// Dictionary<CategoryName, StatusesCounts>
        /// </summary>
        public Dictionary<string, int> CategoriesStatusCounts { get; set; }
    }

    public class GeneralInformations
    {
        public int AllStatusesCount { get; set; }

        public int VideoStatusesCount { get; set; }
        public int QuoteStatusesCount { get; set; }
        public int ImageStatusesCount { get; set; }


        public int CategoriesCount { get; set; }
        public int AppsCount { get; set; }
        public int PostsCount { get; set; }

        public long LikesCount { get; set; }
        public long DownloadsCount { get; set; }
        public long ViewsCount { get; set; }


        /// <summary>
        /// Dictionary<CategoryName, StatusesCounts>
        /// </summary>
        public Dictionary<string, int> CategoriesStatusCounts { get; set; }
    }
}
