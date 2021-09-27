using Mahwous.Core.Models;
using  MahwousMobile.Base.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace  MahwousMobile.Base.Models
{
    public class Category : MahwousWeb.Models.Models.Category
    {
        [Ignore]
        public override IList<MahwousWeb.Models.Models.Status> Statuses { get => base.Statuses; set => base.Statuses = value; }
    }
}
