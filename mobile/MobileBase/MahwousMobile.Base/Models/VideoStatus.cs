using Mahwous.Core.Interfaces.Identity;
using SQLite;
using System.Collections.Generic;

namespace MahwousMobile.Base.Models
{
    public class VideoStatus : Mahwous.Core.Entities.VideoStatus
    {
        [Ignore]
        public override IList<Mahwous.Core.Entities.Category> Categories { get => base.Categories; set => base.Categories = value; }


        [Ignore]
        public override IUser User { get; set; }
    }
}
