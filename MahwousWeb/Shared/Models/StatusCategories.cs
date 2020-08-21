using System;
using System.Collections.Generic;
using System.Text;

namespace MahwousWeb.Shared.Models
{
    public class StatusCategories
    {
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        //// override object.Equals
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || GetType() != obj.GetType())
        //    {
        //        return false;
        //    }

        //    StatusCategories first = this;
        //    StatusCategories second = obj as StatusCategories;

        //    bool result = true;

        //    result &= first.StatusId == second.StatusId;
        //    result &= first.CategoryId == second.CategoryId;

        //    return result;
        //}

    }
}
