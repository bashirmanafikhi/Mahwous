using System.IO;

namespace Mahwous.Service.ViewModels.Reports
{
    public class CreateReportCommand
    {
        public string Details { get; set; }
        public string ViolatorId { get; set; }
    }
}
