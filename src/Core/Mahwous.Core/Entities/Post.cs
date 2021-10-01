
using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }

        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }

        // Get Properties
        public new Type FilterType => typeof(PostFilter);
    }
}
