namespace Jalasoft.Eva.Evaluations.Services.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public class AnswersStubService : IAnswersService, IRegistrableFactory<IAnswersService>
    {
        public IAnswersService CreateInstance()
        {
            return new AnswersStubService();
        }

        public EvaluationScore GetAnswer(Guid idAnswer)
        {
            var answers = new EvaluationScore()
            {
                Id = idAnswer,
                IdEvaluation = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Date = DateTime.Parse("2019-02-28T12:12:00.5973309Z"),
                Score = 0.0,
                Owner = "anonymous"
            };

            return answers;
        }

        public IList<EvaluationScore> GetAnswers(Guid idEvaluation)
        {
            var answers = new List<EvaluationScore>();
            answers.Add(new EvaluationScore()
            {
                Id = Guid.NewGuid(),
                IdEvaluation = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Date = DateTime.Parse("2019-02-28T12:12:00.5973309Z"),
                Score = 0,
                Owner = "anonymous 1"
            });

            answers.Add(new EvaluationScore()
            {
                Id = Guid.NewGuid(),
                IdEvaluation = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Date = DateTime.Parse("2019-03-10T12:12:00.5973309Z"),
                Score = 100,
                Owner = "anonymous 2"
            });

            return answers;
        }

        public EvaluationScore CreateAnswers(Guid idEvaluation, EvaluationAnswer answersList)
        {
            return new EvaluationScore()
            {
                Id = Guid.NewGuid(),
                IdEvaluation = answersList.IdEvaluation,
                Date = DateTime.Parse("2019-02-28T12:12:00.5973309Z"),
                Score = 0,
                Owner = "anonymous 1"
            };
        }
    }
}
