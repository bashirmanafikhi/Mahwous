using SQLite;
using System.Collections.Generic;

namespace MahwousMobile.Base.Models
{
    public class QuoteStatus : Mahwous.Core.Entities.QuoteStatus
    {
        [Ignore]
        public override IList<Mahwous.Core.Entities.Category> Categories { get => base.Categories; set => base.Categories = value; }
    }
}
