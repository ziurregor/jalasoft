using Jalasoft.BackEnd.Model;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using Jalasoft.BackEnd.Dao;
using System.Collections.Generic;
using System.Linq.Expressions;
using Jalasoft.BackEnd.Dao.entitys;

namespace Jalasoft.BackEnd.Dao.Mongo
{
    public class MongoRepository<T> : IRepository<T, ObjectId> where T : EntityBase<ObjectId>
    {
        public static IMongoDatabase database;
        public static IMongoCollection<T> collection;
        public MongoRepository(string table)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("test");
            collection = database.GetCollection<T>(table);
        }

        public IEnumerable<T> ReadUsersCollection()
        {
            JsonWriterSettings.Defaults.Indent = true;
            //foreach (var users in collection.Find(_ => true).ToListAsync().Result)
            //{
            //    Console.WriteLine(users.ToJson());
            //}
            return collection.Find(_ => true).ToListAsync().Result;
        }

        public static void InsertUsersCollection(T u)
        {
            JsonWriterSettings.Defaults.Indent = true;
            //var newUser = new BsonDocument
            //{
            //    { "email", new BsonString("rr@rr.com")}
            //};
            //var u = new chatUser();
            //u.email = "rr@rr.c";

            collection.InsertOneAsync(u);


        }

        public static void DeleteUsersCollectionl(T u)
        {
            JsonWriterSettings.Defaults.Indent = true;

            //var newUser = new BsonDocument
            //{
            //    { "email", new BsonString("rr@rr.com")}
            //};
            //var u = new chatUser();
            //u.email = "rr@rr.c";

            collection.InsertOneAsync(u);


        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
