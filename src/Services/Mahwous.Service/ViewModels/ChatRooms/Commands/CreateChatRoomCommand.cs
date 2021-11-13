using System.IO;

namespace Mahwous.Service.ViewModels.ChatRooms
{
    public class CreateChatRoomCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Stream Cover { get; set; }
    }
}
