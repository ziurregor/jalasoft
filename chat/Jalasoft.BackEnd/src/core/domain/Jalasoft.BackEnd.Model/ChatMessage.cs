using Jalasoft.BackEnd.Dao.entitys;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.BackEnd.Model
{
    public class ChatMessage : EntityBase<ObjectId>
    {
        //public int idUser { get; set; }
        public string message { get; set; }
    }
}
