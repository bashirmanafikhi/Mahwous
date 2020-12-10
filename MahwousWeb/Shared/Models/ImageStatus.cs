using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Shared.Models
{
    public class ImageStatus : Status
    {
        [Required]
        public string ImagePath { get; set; }
    }
}