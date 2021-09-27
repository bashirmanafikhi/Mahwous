//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

//namespace MahwousWeb.Models.Models
//{
//    public class Notification : ModelBase
//    {
//        [Required]
//        public string Title { get; set; }
//        [Required]
//        public string Description { get; set; }
//        public string ReturningData { get; set; }
//        public int BadgeNumber { get; set; }
//        public int RecivedCount { get; set; }
//        public int OpenedCount { get; set; }

//        public bool IsScheduled{ get; set; }
//        public DateTime? NotifyTime { get; set; }


//        public ICollection<MobileApp> Apps { get; set; }
//    }
//}
