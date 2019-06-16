using System;
using System.Collections.Generic;

namespace Jalasoft.BackEnd.Model
{
    public class ChatUser
    {
        public int id { get; set; }
        public string email { get; set; }
        public ICollection<ChatMessage> messages { get; set; }
    }
}
