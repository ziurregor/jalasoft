using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.BackEnd.Model
{
    public class ChatMessage
    {
        public int id { get; set; }
        public int idUser { get; set; }
        public string message { get; set; }
    }
}
