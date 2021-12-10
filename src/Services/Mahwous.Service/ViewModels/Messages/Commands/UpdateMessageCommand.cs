using System.IO;

namespace Mahwous.Service.ViewModels.Messages
{
    public class UpdateMessageCommand
    {
        public int Id { get; set; }
        public string Content { get; set; }
    }
}
