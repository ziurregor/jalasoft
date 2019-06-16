namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils;
    using Jalasoft.Eva.Evaluations.Services.Impl.Tests.Helpers;
    using Xunit;

    public class MathParserCalculatorTests
    {
        [Fact]
        public void TestGetEvaluationScore()
        {
            var evaluationTemplate = Samples.CompleteEvaluation;
            evaluationTemplate.QuestionList.ToList()[0].Score = 10;
            evaluationTemplate.QuestionList.ToList()[1].Score = 0;
            var calculator = new MathParserCalculator(evaluationTemplate);
            var expected = 10;
            var actual = calculator.GetEvaluationScore();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetCorrectAnswers()
        {
            var evaluationTemplate = Samples.CompleteEvaluation;
            var calculator = new MathParserCalculator(evaluationTemplate);
            var question = evaluationTemplate.QuestionList.ToList()[0];
            var expected = new List<OptionScore>() { question.OptionList[0] };
            var actual = calculator.GetCorrectUserOptions(question);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetQuestionScore()
        {
            var calculator = new MathParserCalculator(Samples.CompleteEvaluation);
            var question = Samples.CompleteEvaluation.QuestionList.ToList()[0];
            var expected = 10;
            var actual = calculator.GetQuestionScore(question);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetQuestionScore_Half_Correct_Answer()
        {
            var calculator = new MathParserCalculator(Samples.CompleteEvaluation);
            var question = Samples.CompleteEvaluation.QuestionList.ToList()[1];
            var expected = 5;
            var actual = calculator.GetQuestionScore(question);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateQuestionsScores()
        {
            var evaluationTemplate = Samples.CompleteEvaluation;
            var calculator = new MathParserCalculator(evaluationTemplate);
            var evaluation = Samples.Evaluation;
            calculator.CalculateQuestions();

            var questionLists = evaluationTemplate.QuestionList as List<QuestionScore>;

            Assert.Equal(questionLists[0].Score, evaluation.Body[0].Questions[0].Weight);
            Assert.Equal(5, questionLists[1].Score);
        }

        [Fact]
        public void TestGetEvaluationTotalWeight()
        {
            var evaluationTemplate = Samples.CompleteEvaluation;
            var calculator = new MathParserCalculator(evaluationTemplate);
            var expected = 20;
            int actual = calculator.GetTotalEvaluationWeight();

            Assert.Equal(expected, actual);
        }
    }
}
