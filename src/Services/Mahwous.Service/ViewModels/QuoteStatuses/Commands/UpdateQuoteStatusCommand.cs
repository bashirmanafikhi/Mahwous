using System.IO;

namespace Mahwous.Service.ViewModels.QuoteStatuses
{
    public class UpdateQuoteStatusCommand
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Stream Cover { get; set; }
    }
}
