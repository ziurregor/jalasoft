namespace Jalasoft.Eva.Evaluations.Dao
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;

    public interface IEvaluationsDao
    {
        PaginatedList<Evaluation> GetEvaluations(QueryParameters queryParameters);

        IList<Evaluation> GetEvaluations();

        Evaluation GetEvaluation(Guid id);

        void DeleteEvaluation(Guid id);

        Evaluation CreateEvaluation(Evaluation evaluation);

        void UpdateEvaluation(Evaluation evaluation);

        bool EvaluationExists(Guid id);
    }
}
