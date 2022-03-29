
using Mahwous.Core.Interfaces.Identity;
using System;
using System.Collections.Generic;

namespace Mahwous.Core.Entities
{
    public class Report : BaseEntity
    {
        public string Details { get; set; }

        public string ViolatorId { get; set; }
        public virtual IUser Violator { get; set; }
    }
}
