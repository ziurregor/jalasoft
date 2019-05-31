namespace Jalasoft.Eva.Evaluations.Dao.Mongo.Builders
{
    using System.Text.RegularExpressions;
    using MongoDB.Bson;

    public class MongoFilter : IQueryBuilder
    {
        public BsonDocument BuildQuery(string property, string criteria)
        {
            var regex = new Regex(criteria);
            return new BsonDocument
            {
                {
                    "$match", new BsonDocument
                    {
                        {
                            property, regex
                        }
                    }
                }
            };
        }
    }
}
