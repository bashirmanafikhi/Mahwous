//using System;
//using System.ComponentModel.DataAnnotations;

//namespace MahwousWeb.Models.Models
//{
//    public abstract class ModelBase
//    {
//        [Key]
//        public int Id { get; set; }
//        public bool Visible { get; set; } 
//        public int ViewsCount { get; set; }

//        [DataType(DataType.Date)]
//        public DateTime Date { get; set; }

//        public ModelBase()
//        {
//            Date = DateTime.Now;
//            Date = Date.AddSeconds(-Date.Second);
//            Visible = true;
//        }
//    }
//}
