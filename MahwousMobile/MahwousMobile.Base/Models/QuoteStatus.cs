using MahwousWeb.Models.Models;
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
        public override IList<StatusCategories> StatusCategories { get => base.StatusCategories; set => base.StatusCategories = value; }
    }
}
