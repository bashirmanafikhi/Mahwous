using Mahwous.Core.Interfaces.Identity;
using SQLite;
using System.Collections.Generic;

namespace MahwousMobile.Base.Models
{
    public class Category : Mahwous.Core.Entities.Category
    {
        [Ignore]
        public override IList<Mahwous.Core.Entities.Status> Statuses { get => base.Statuses; set => base.Statuses = value; }

        [Ignore]
        public override IUser User { get; set; }
    }
}
