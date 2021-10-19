using SQLite;
using System.Collections.Generic;

namespace MahwousMobile.Base.Models
{
    public class Status : Mahwous.Core.Entities.Status
    {
        [Ignore]
        public override IList<Mahwous.Core.Entities.Category> Categories { get => base.Categories; set => base.Categories = value; }
    }
}
