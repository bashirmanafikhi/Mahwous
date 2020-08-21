using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class App
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string PlayStoreLink { get; set; }

        [DataType(DataType.Url)]
        public string AppleStoreLink { get; set; }


        public App()
        {
            
        }
    }
}
