namespace Jalasoft.Eva.Evaluations.Dao.Mongo.Builders
{
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class QueryBuilder
    {
        private List<BsonDocument> bsonList = new List<BsonDocument>();

        public QueryBuilder()
        {
        }

        public BsonDocumentStagePipelineDefinition<BsonDocument, BsonDocument> BuildPipeline(QueryParameters queryParams)
        {
            if (queryParams.SearchCriteria != null
                && !string.IsNullOrEmpty(queryParams.SearchCriteria.Property)
                && !string.IsNullOrEmpty(queryParams.SearchCriteria.MatchInput))
            {
                this.bsonList.Add(new MongoFilter().BuildQuery(queryParams.SearchCriteria.Property, queryParams.SearchCriteria.MatchInput));
            }

            if (queryParams.SortCriteria != null
                && !string.IsNullOrEmpty(queryParams.SortCriteria.Property))
            {
                var sortOption = queryParams.SortCriteria.SortOption;
                var mongoSort = (sortOption == SortOption.Ascendent) ? "1" : "-1";
                this.bsonList.Add(new MongoSort().BuildQuery(queryParams.SortCriteria.Property, mongoSort));
            }

            return new BsonDocumentStagePipelineDefinition<BsonDocument, BsonDocument>(this.bsonList);
        }
    }
}
