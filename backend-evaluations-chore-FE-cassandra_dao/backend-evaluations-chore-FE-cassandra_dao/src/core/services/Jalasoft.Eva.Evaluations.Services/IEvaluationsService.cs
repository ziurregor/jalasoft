namespace Jalasoft.Eva.Evaluations.Services
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;

    public interface IEvaluationsService
    {
        Evaluation CreateEvaluation(Evaluation evaluation);

        void DeleteEvaluation(Guid id);

        Evaluation GetEvaluation(Guid id);

        IList<Evaluation> GetEvaluations();

        PaginatedList<Evaluation> GetEvaluations(QueryParameters queryParameters);

        void UpdateEvaluation(Evaluation evaluation);
    }
}
