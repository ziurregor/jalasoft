namespace Jalasoft.Eva.Evaluations.Dao.Mongo
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class MongoEvaluation
    {
        [BsonId]
        public ObjectId PaginationId { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? EditDate { get; set; }

        public string Reply { get; set; }

        public Guid IdTemplate { get; set; }

        public List<Data> Headers { get; set; }

        public List<Section> Body { get; set; }

        public List<QualificationRange> QualificationRanges { get; set; }
    }
}
