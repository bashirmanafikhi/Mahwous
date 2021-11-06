using System;
using System.Collections.Generic;
using System.Text;

namespace Mahwous.Service.Chat
{
    public class MessageModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public bool IsOwnerMessage { get; set; }
    }
}
