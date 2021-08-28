using MahwousWeb.Models.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace  MahwousMobile.Base.Models
{
    public class VideoStatus : MahwousWeb.Models.Models.VideoStatus
    {
        [Ignore]
        public override IList<StatusCategories> StatusCategories { get => base.StatusCategories; set => base.StatusCategories = value; }
    }
}
