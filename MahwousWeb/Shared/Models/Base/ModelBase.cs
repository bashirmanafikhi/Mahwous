using System;
using System.ComponentModel.DataAnnotations;

namespace MahwousWeb.Shared.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public bool Visible { get; set; } 
        public int ViewsCount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public ModelBase()
        {
            Date = DateTime.UtcNow;
            Date = Date.AddSeconds(-Date.Second);
            Visible = true;
        }
    }
}
