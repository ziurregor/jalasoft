namespace Jalasoft.Eva.Evaluations.Dao.Mongo
{
    using System;
    using System.Collections.Generic;
    using Evaluations.Dao.Mongo.Adapters;
    using Jalasoft.Eva.Evaluations.Dao.Mongo;
    using Jalasoft.Eva.Evaluations.Dao.Mongo.Resources;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using MongoDB.Driver;

    public class EvaluationsMongoDao : AbstractMongoDao<MongoEvaluation>, IEvaluationsDao, IDaoBuilder<IEvaluationsDao>
    {
        private EvaluationsAdapter mongoAdapter = new EvaluationsAdapter();

        public EvaluationsMongoDao(string connectionString, string collection)
            : base(connectionString, collection)
        {
        }

        public IEvaluationsDao Create()
        {
            return new EvaluationsMongoDao(this.connection, this.collection);
        }

        public Evaluation CreateEvaluation(Evaluation evaluation)
        {
            this.GenerateIdsForEvaluation(evaluation);
            var mongoEvaluation = this.mongoAdapter.ToMongo(evaluation);
            this.ExecuteQuery(collection =>
            {
                return collection.InsertOneAsync(mongoEvaluation);
            });

            return evaluation;
        }

        public void GenerateIdsForEvaluation(Evaluation evaluation)
        {
            evaluation.Id = Guid.NewGuid();
            foreach (var section in evaluation.Body)
            {
                section.Id = Guid.NewGuid();
                foreach (var question in section.Questions)
                {
                    question.Id = Guid.NewGuid();
                    foreach (var option in question.Options)
                    {
                        option.Id = Guid.NewGuid();
                    }
                }
            }

            foreach (var range in evaluation.QualificationRanges)
            {
                range.Id = Guid.NewGuid();
            }
        }

        public void DeleteEvaluation(Guid id)
        {
            this.ExecuteQuery(collection => collection.DeleteOneAsync(evaluation => evaluation.Id == id));
        }

        public Evaluation GetEvaluation(Guid id)
        {
            return this.ExecuteQuery(collection =>
            {
                var mongoEval = collection.Find<MongoEvaluation>(eval => eval.Id == id).FirstOrDefault();
                var evaluation = this.mongoAdapter.FromMongo(mongoEval);
                return evaluation;
            });
        }

        public IList<Evaluation> GetEvaluations()
        {
            return this.ExecuteQuery(collection =>
            {
                var mongoEvaluations = collection.Find<MongoEvaluation>(_ => true).ToListAsync().Result;
                return this.mongoAdapter.FromMongo(mongoEvaluations);
            });
        }

        public PaginatedList<Evaluation> GetEvaluations(QueryParameters queryParams)
        {
            return this.ExecutePaginatedQuery(
                (collection, totalLength) =>
                {
                    if (totalLength == 0)
                    {
                        return new PaginatedList<Evaluation>(new List<Evaluation>(), totalLength);
                    }

                    var limit = 1 + (queryParams.PageSize * (queryParams.PageNumber - 1));
                    var firstDoc = collection.Find<MongoEvaluation>(_ => true).Limit(limit).ToListAsync().Result.FindLast(_ => true).PaginationId;
                    var filter = Builders<MongoEvaluation>.Filter.Gte(MongoConstants.PaginationId, firstDoc);
                    if (queryParams.SortCriteria != null && queryParams.SortCriteria.SortOption == SortOption.Descendent)
                    {
                        filter = Builders<MongoEvaluation>.Filter.Lte(MongoConstants.PaginationId, firstDoc);
                    }

                    var mongoEvaluations = collection.Find<MongoEvaluation>(filter).Limit(queryParams.PageSize).ToListAsync().Result;
                    var evaluations = this.mongoAdapter.FromMongo(mongoEvaluations);
                    return new PaginatedList<Evaluation>(evaluations, totalLength);
                }, queryParams);
        }

        public void UpdateEvaluation(Evaluation evaluation)
        {
            foreach (var evaluationBody in evaluation.Body)
            {
                if (evaluationBody.Id.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                {
                    evaluationBody.Id = Guid.NewGuid();
                }

                foreach (var section in evaluationBody.Questions)
                {
                    foreach (var item in section.Options)
                    {
                        if (section.Id.ToString().Equals("00000000-0000-0000-0000-000000000000"))
                        {
                            section.Id = Guid.NewGuid();
                        }
                    }
                }
            }

            var filter = Builders<MongoEvaluation>.Filter.Eq(eval => eval.Id, evaluation.Id);
            var update = Builders<MongoEvaluation>.Update
                .Set(eval => eval.EditDate, evaluation.EditDate)
                .Set(eval => eval.Name, evaluation.Name)
                .Set(eval => eval.Reply, evaluation.Reply)
                .Set(eval => eval.Body, evaluation.Body)
                .Set(eval => eval.QualificationRanges, evaluation.QualificationRanges)
                .Set(eval => eval.Headers, evaluation.Headers);
            this.ExecuteQuery(del => del.FindOneAndUpdateAsync(filter, update));
        }

        public bool EvaluationExists(Guid id)
        {
            bool exists = false;
            var result = this.ExecuteQuery(collection => collection.Find<MongoEvaluation>(evaluation => evaluation.Id == id));
            if (result.CountDocuments() == 1)
            {
                exists = true;
            }

            return exists;
        }
    }
}
