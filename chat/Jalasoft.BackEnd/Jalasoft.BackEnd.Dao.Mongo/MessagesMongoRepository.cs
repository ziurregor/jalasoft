using Jalasoft.BackEnd.Dao.entitys;
using Jalasoft.BackEnd.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jalasoft.BackEnd.Dao.Mongo
{
    public class MessagesMongoRepository : MongoRepository<ChatMessage>
    {
        public MessagesMongoRepository(string table) : base(table)
        {
        }

    }
}
