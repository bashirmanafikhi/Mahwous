using Mahwous.Core.Entities;
using  MahwousMobile.Base.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace  MahwousMobile.Base.Models
{
    public class ImageStatus : MahwousWeb.Models.Models.ImageStatus
    {
        [Ignore]
        public override IList<MahwousWeb.Models.Models.Category> Categories { get => base.Categories; set => base.Categories = value; }
    }
}
