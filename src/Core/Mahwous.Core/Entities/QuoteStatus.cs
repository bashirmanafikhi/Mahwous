
using Mahwous.Core.Enums;
using Mahwous.Core.Filters;
using System;

namespace Mahwous.Core.Entities
{
    public class QuoteStatus : Status
    {
        public string Content { get; set; }

        // Get Properties
        public new Type FilterType => typeof(QuoteFilter);
        public StatusType StatusType => StatusType.Quote;
    }
}
