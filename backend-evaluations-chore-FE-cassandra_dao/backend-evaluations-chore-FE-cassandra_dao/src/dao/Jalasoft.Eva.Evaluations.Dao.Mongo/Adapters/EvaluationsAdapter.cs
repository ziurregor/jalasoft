namespace Jalasoft.Eva.Evaluations.Dao.Mongo.Adapters
{
    using System.Collections.Generic;
    using AutoMapper;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;

    public class EvaluationsAdapter
    {
        private readonly IMapper evaluationsMapper;

        public EvaluationsAdapter()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Evaluation, MongoEvaluation>());
            this.evaluationsMapper = config.CreateMapper();
        }

        public MongoEvaluation ToMongo(Evaluation evaluation)
        {
            return this.evaluationsMapper.Map<MongoEvaluation>(evaluation);
        }

        public List<MongoEvaluation> ToMongo(List<Evaluation> evaluations)
        {
            return this.evaluationsMapper.Map<List<MongoEvaluation>>(evaluations);
        }

        public Evaluation FromMongo(MongoEvaluation mongoEvaluation)
        {
            return this.evaluationsMapper.Map<Evaluation>(mongoEvaluation);
        }

        public List<Evaluation> FromMongo(List<MongoEvaluation> mongoEvaluations)
        {
            return this.evaluationsMapper.Map<List<Evaluation>>(mongoEvaluations);
        }
    }
}
