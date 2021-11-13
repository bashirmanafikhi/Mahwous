using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public class ImageStatus : Status
    {
        public string ImagePath { get; set; }

        // Get Properties
        public new Type FilterType => typeof(ImageFilter);
        public StatusType StatusType => StatusType.Image;
    }
}