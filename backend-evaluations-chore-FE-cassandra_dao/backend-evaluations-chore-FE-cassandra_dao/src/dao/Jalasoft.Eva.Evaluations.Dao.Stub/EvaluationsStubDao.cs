namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;

    public class EvaluationsStubDao : IEvaluationsDao, IDaoBuilder<IEvaluationsDao>
    {
        public EvaluationsStubDao()
        {
        }

        public IEvaluationsDao Create()
        {
            return new EvaluationsStubDao();
        }

        PaginatedList<Evaluation> IEvaluationsDao.GetEvaluations(QueryParameters queryParameters)
        {
            return new PaginatedList<Evaluation>(Memory.Evaluations.List, Memory.Evaluations.List.Count);
        }

        public IList<Evaluation> GetEvaluations()
        {
            return Memory.Evaluations.List;
        }

        public Evaluation GetEvaluation(Guid id)
        {
            return Memory.Evaluations.Get(id);
        }

        public void DeleteEvaluation(Guid id)
        {
            Memory.Evaluations.Remove(id);
        }

        public Evaluation CreateEvaluation(Evaluation evaluation)
        {
            evaluation.Id = Guid.NewGuid();
            Memory.Evaluations.List.Add(evaluation);
            return Memory.Evaluations.Get(evaluation.Id);
        }

        public void UpdateEvaluation(Evaluation evaluation)
        {
            Evaluation target = this.GetEvaluation(evaluation.Id);
            target.Name = evaluation.Name;
        }

        public bool EvaluationExists(Guid id)
        {
            return Memory.Evaluations.List.Exists(x => x.Id == id);
        }
    }
}