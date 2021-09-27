using Mahwous.Core.Models;
using  MahwousMobile.Base.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace  MahwousMobile.Base.Models
{
    public class QuoteStatus : MahwousWeb.Models.Models.QuoteStatus
    {
        [Ignore]
        public override IList<MahwousWeb.Models.Models.Category> Categories { get => base.Categories; set => base.Categories = value; }
    }
}
