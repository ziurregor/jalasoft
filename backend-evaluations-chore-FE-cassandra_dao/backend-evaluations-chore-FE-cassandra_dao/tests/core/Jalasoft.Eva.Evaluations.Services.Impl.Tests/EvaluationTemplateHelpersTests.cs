namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils;
    using Jalasoft.Eva.Evaluations.Services.Impl.Tests.Helpers;
    using Xunit;

    public class EvaluationTemplateHelpersTests
    {
        public EvaluationTemplateHelpersTests()
        {
            this.Template = Samples.Template;
            this.Evaluation = Samples.Evaluation;
            this.Expected = Samples.EvaluationTemplate;
            this.CompleteEvaluation = Samples.CompleteEvaluation;
        }

        private Template Template { get; set; }

        private Evaluation Evaluation { get; set; }

        private EvaluationScore Expected { get; set; }

        private EvaluationScore CompleteEvaluation { get; set; }

        [Fact]
        public void TestGenerateEvaluationTemplate()
        {
            var actual = EvaluationScoreHelpers.GenerateEvaluationTemplate(this.Template, this.Evaluation);

            Assert.Equal(this.Expected.IdEvaluation, actual.IdEvaluation);
        }

        [Fact]
        public void TestZipQuestionLists()
        {
            var templateQuestions = this.Template.Body;
            var evalautionQuestions = this.Evaluation.Body;
            var expected = this.Expected.QuestionList.ToList();
            var actual = EvaluationScoreHelpers.JoinQuestionLists(templateQuestions, evalautionQuestions);

            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void TestGetTemplateOptions()
        {
            var evaluationQuestion = this.Evaluation.Body[0].Questions[0].Options;
            var expected = this.Expected.QuestionList.ToList()[0].OptionList;
            var actual = EvaluationScoreHelpers.GetOptionsTemplateFrom(evaluationQuestion);

            Assert.Equal(expected.Count, actual.Count);
        }

        [Fact]
        public void TestAppendAnswers()
        {
            var answerList = new EvaluationAnswer()
            {
                IdEvaluation = this.Evaluation.Id,
                Owner = "annonymous",
                Sections = new List<SectionAnswer>()
                {
                    new SectionAnswer()
                    {
                        QuestionAnswers = new List<QuestionAnswer>()
                        {
                            new QuestionAnswer()
                            {
                                IdQuestion = this.Evaluation.Body[0].Questions[0].Id,
                                SelectedAnswersIds = new List<Guid>()
                                {
                                    this.Evaluation.Body[0].Questions[0].Options[0].Id
                                }
                            },
                            new QuestionAnswer()
                            {
                                IdQuestion = this.Evaluation.Body[0].Questions[1].Id,
                                SelectedAnswersIds = new List<Guid>()
                                {
                                    this.Evaluation.Body[0].Questions[1].Options[1].Id,
                                    this.Evaluation.Body[0].Questions[1].Options[0].Id,
                                    this.Evaluation.Body[0].Questions[0].Options[0].Id
                                }
                            }
                        }
                    }
                }
            };
            EvaluationScoreHelpers.AppendAnswers(this.Expected, answerList);

            Assert.Equal(answerList.Sections[0].QuestionAnswers[0].SelectedAnswersIds, this.Expected.QuestionList.ToList()[0].Answers.ToList());
            Assert.Equal(answerList.Sections[0].QuestionAnswers[1].SelectedAnswersIds, this.Expected.QuestionList.ToList()[1].Answers.ToList());
        }

        [Fact]
        public void TestSetCorrectOptions()
        {
            var evaluation = Samples.Evaluation;
            var question = Samples.CompleteEvaluation.QuestionList.ToList()[0];
            question = question.SetCorrectOptions();
            var actual = question.OptionList[0];

            Assert.True(actual.IsAnswer);
        }

        [Fact]
        public void TestSetUserSelectedOptions()
        {
            var evaluation = Samples.Evaluation;
            var question = Samples.CompleteEvaluation.QuestionList.ToList()[0];
            question = question.SetUserSelectedOptions();
            var actual = question.OptionList[0];

            Assert.True(actual.UserSelected);
        }
    }
}
