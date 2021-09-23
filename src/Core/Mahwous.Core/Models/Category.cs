using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

namespace Mahwous.Core.Models
{

    public class Category : ModelBase
    {
        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string CoverPath { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;


        // [Ignore] // this attribute for sqlite in xamarin
        public virtual IList<StatusCategories> StatusCategories { get; set; }

    }
}
