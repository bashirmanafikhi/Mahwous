using System.IO;

namespace Mahwous.Service.ViewModels.ChatRooms
{
    public class UpdateChatRoomCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Stream Cover { get; set; }
    }
}
