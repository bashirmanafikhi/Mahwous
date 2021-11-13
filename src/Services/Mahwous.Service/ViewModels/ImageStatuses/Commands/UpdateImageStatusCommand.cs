using System.IO;

namespace Mahwous.Service.ViewModels.ImageStatuses
{
    public class UpdateImageStatusCommand
    {
        public int Id { get; set; }
        public Stream Image { get; set; }
    }
}
