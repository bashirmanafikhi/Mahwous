using Mahwous.Core.Entities;
using System.IO;

namespace Mahwous.Service.ViewModels.QuoteStatuses
{
    public class CreateQuoteStatusCommand 
    {
        public string Content { get; set; }

        public Stream Cover { get; set; }
    }
}
