using Jalasoft.BackEnd.Dao.entitys;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Jalasoft.BackEnd.Model
{
    public class ChatUser : EntityBase<int>
    {
        public string email { get; set; }
    }
}
