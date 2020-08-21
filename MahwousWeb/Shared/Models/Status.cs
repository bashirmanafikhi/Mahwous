using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public abstract class Status
    {
        public int Id { get; set; }

        public int ViewsCount { get; set; }
        public int DownloadsCount { get; set; }
        public int LikesCount { get; set; }

        public bool Visible { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public IList<StatusCategories> StatusCategories { get; set; }

        


        public Status()
        {
            Date = DateTime.Now;
            Visible = true;
        }
    }
}
