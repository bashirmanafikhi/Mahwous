using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Shared.Models
{
    public class QuoteStatus : Status
    {
        [Required]
        public string Content { get; set; }

    }
}
