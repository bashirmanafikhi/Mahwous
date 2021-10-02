﻿using Mahwous.Core.Models;
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
        public override IList<MahwousWeb.Models.Models.Category> Categories { get => base.Categories; set => base.Categories = value; }
    }
}