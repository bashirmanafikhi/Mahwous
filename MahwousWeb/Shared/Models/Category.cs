using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MahwousWeb.Shared.Models
{

    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Name { get; set; }

        public string CoverPath { get; set; }

        public bool ForVideos { get; set; }
        public bool ForImages { get; set; }
        public bool ForQuotes { get; set; }

        public IList<StatusCategories> StatusCategories { get; set; }

        public Category()
        {
            ForVideos = true;
            ForImages = true;
            ForQuotes = true;
        }
    }
}
