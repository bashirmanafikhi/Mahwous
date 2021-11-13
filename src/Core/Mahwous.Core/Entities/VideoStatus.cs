
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public class VideoStatus : Status
    {
        public string Title { get; set; }
        public string VideoPath { get; set; }
        public string CoverPath { get; set; }


        // Get Properties
        public new Type FilterType => typeof(VideoFilter);
        public StatusType StatusType => StatusType.Video;
    }
}
