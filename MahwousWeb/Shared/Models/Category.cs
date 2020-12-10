using SQLite;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Shared.Models
{

    public class Category : ModelBase
    {
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string CoverPath { get; set; }

        public bool ForVideos { get; set; } = true;
        public bool ForImages { get; set; } = true;
        public bool ForQuotes { get; set; } = true;


        [Ignore] // this attribute for sqlite in xamarin
        public IList<StatusCategories> StatusCategories { get; set; }

    }
}
