namespace Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests
{
    using System;
    using System.Collections.Generic;
    using global::Cassandra.Mapping;
    using Jalasoft.Eva.Evaluations.Dao.Cassandra.Tests.Utils;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Moq;
    using Xunit;

    public class AnswersDaoTests
    {
        [Fact]
        public void AnswersExist_WhenSendAValidAnswerId_ShouldReturnTrue()
        {
            var idToFind = Guid.NewGuid();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Single<EvaluationScore>(It.IsAny<string>(), idToFind)).Returns(new EvaluationScore());

            var answerDao = new AnswersDao(MockUtils.MockConnectionFactory(mapperMock));
            var existsAnswer = answerDao.AnswersExist(idToFind);
            Assert.True(existsAnswer);
        }

        [Fact]
        public void AnswersDoesNotExist_WhenSendAValidAnswerId_ShouldReturnFalse()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Single<EvaluationScore>(It.IsAny<string>(), It.IsAny<Guid>())).Throws<InvalidOperationException>();

            var answerDao = new AnswersDao(MockUtils.MockConnectionFactory(mapperMock));
            var existsAnswer = answerDao.AnswersExist(Guid.NewGuid());
            Assert.False(existsAnswer);
        }

        [Fact]
        public void GetAnswers_WhenSendAnValidId_ShouldReturnTheAnswer()
        {
            var idToFind = Guid.NewGuid();

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Single<EvaluationScore>(It.IsAny<string>(), idToFind)).Returns(new EvaluationScore() { Id = idToFind });

            var answerDao = new AnswersDao(MockUtils.MockConnectionFactory(mapperMock));
            var answer = answerDao.GetAnswer(idToFind);

            Assert.Equal(answer.Id, idToFind);
        }

        [Fact]
        public void CreateAnswers_WhenSendAValidObject_ShouldCreateAndReturnObject()
        {
            var connectionMock = new CassandraConnection("answers", "localhost");
            var mapperMock = new Mock<IMapper>();
            var expected = new EvaluationScore()
            {
                Id = Guid.NewGuid(),
                IdEvaluation = Guid.NewGuid(),
                Qualification = Guid.NewGuid(),
                Date = DateTime.Now,
                Name = "TestName",
                Owner = "TestOwner",
                Score = 50,
                ScoreFormula = "Formula",
                Weight = 12,
                QuestionList = new List<QuestionScore>()
                {
                    new QuestionScore()
                    {
                        IdQuestion = Guid.NewGuid(),
                        Answers = new List<Guid>(),
                        Score = 5,
                        ScoreFormula = "QS1",
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore() { IdOption = Guid.NewGuid(), IsAnswer = true, Sequence = 1, UserSelected = false, Weight = 3 }
                        }
                    },
                    new QuestionScore()
                    {
                        IdQuestion = Guid.NewGuid(),
                        Answers = new List<Guid>(),
                        Score = 5,
                        ScoreFormula = "QS2",
                        OptionList = new List<OptionScore>()
                    },
                },
                QualificationRanges = new List<QualificationRange>()
                {
                    new QualificationRange() { Id = Guid.NewGuid(), Start = 100, End = 0, Qualification = "GOOD" }
                },
            };

            mapperMock.Setup(m => m.Insert(expected, null)).Verifiable();
            mapperMock.Setup(m => m.Single<EvaluationScore>(It.IsAny<string>(), It.IsAny<Guid>())).Returns(expected);

            var answerDao = new AnswersDao(MockUtils.MockConnectionFactory(mapperMock));
            var response = answerDao.CreateAnswers(expected);
            Assert.Equal(expected.Id, response.Id);
        }

        [Fact]
        public void GetAnswers_WhenSendAnEvaluationId_ShouldReturnAsnwers()
        {
            var evaluationId = Guid.NewGuid();

            var expected = new List<EvaluationScore>()
            {
                new EvaluationScore() { Id = Guid.NewGuid(), IdEvaluation = evaluationId },
                new EvaluationScore() { Id = Guid.NewGuid(), IdEvaluation = evaluationId },
            };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Fetch<EvaluationScore>(It.IsAny<string>(), evaluationId)).Returns(expected);

            var answerDao = new AnswersDao(MockUtils.MockConnectionFactory(mapperMock));
            var answer = answerDao.GetAnswers(evaluationId);

            Assert.Equal(2, answer.Count);
        }
    }
}
