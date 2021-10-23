﻿using System.Collections.Generic;

namespace Mahwous.Core.General
{
    public class Informations
    {
        public int Count { get; set; }

        public long LikesCount { get; set; }
        public long DownloadsCount { get; set; }
        public long SharesCount { get; set; }
        public long ViewsCount { get; set; }

        public Dictionary<string, int> CategoriesStatusCounts { get; set; }

        public Informations()
        {
            CategoriesStatusCounts = new Dictionary<string, int>();
        }
    }
}
