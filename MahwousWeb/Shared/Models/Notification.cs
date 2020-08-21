using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }


        public DateTime Date { get; set; }

        public int RecivedCount { get; set; }
        public int OpenedCount { get; set; }

        public Notification()
        {
            Date = DateTime.Now;
        }
    }
}
