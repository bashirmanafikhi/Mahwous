using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class QuoteStatus : Status
    {
        [Required]
        public string Content { get; set; }

    }
}
