using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Models.Models
{
    public class ImageStatus : Status
    {
        [Required]
        public string ImagePath { get; set; }
    }
}