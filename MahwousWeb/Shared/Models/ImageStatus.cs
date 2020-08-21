using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class ImageStatus : Status
    {
        [Required]
        public string ImagePath { get; set; }
    }
}