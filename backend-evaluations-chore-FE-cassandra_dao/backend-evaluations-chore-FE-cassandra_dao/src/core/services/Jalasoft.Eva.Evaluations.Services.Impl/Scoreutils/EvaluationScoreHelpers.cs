namespace Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils
{
    using System.Collections.Generic;
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Answers;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public static class EvaluationScoreHelpers
    {
        public static EvaluationScore GenerateEvaluationTemplate(Template template, Evaluation evaluation)
        {
            var evaluationTemplate = new EvaluationScore()
            {
                IdEvaluation = evaluation.Id,
                ScoreFormula = template.ScoreFormula,
                Name = evaluation.Name,
                QualificationRanges = evaluation.QualificationRanges
            };

            if (template.Id != evaluation.IdTemplate)
            {
                return evaluationTemplate;
            }

            evaluationTemplate.QuestionList = JoinQuestionLists(template.Body, evaluation.Body);
            return evaluationTemplate;
        }

        public static List<QuestionScore> JoinQuestionLists(List<QuestionField> templateBody, List<Section> evaluationBody)
        {
            var questions = evaluationBody.SelectMany(p => p.Questions);

            return templateBody.Join(
                questions,
                templateQuestion => templateQuestion.Id,
                evaluationQuestion => evaluationQuestion.IdTemplateQuestionField,
                (templateQuestion, evaluationQuestion) =>
                new QuestionScore()
                {
                    IdQuestion = evaluationQuestion.Id,
                    ScoreFormula = templateQuestion.ScoreFormula,
                    Weight = evaluationQuestion.Weight,
                    Weighted = evaluationQuestion.Weighted,
                    OptionList = GetOptionsTemplateFrom(evaluationQuestion.Options)
                }).ToList();
        }

        public static List<OptionScore> GetOptionsTemplateFrom(List<ChoiceAnswer> optionList)
        {
            return optionList.Select(option => new OptionScore()
            {
                IdOption = option.Id,
                Sequence = option.Sequence,
                Weight = option.Weight
            }).ToList();
        }

        public static void AppendAnswers(this EvaluationScore evaluationTemplate, EvaluationAnswer answers)
        {
            evaluationTemplate.Date = answers.Date;
            evaluationTemplate.Owner = answers.Owner;
            var questionAnswers = answers.Sections.SelectMany(p => p.QuestionAnswers);

            questionAnswers.Join(
                evaluationTemplate.QuestionList,
                questionAnswer => questionAnswer.IdQuestion,
                evaluationQuestion => evaluationQuestion.IdQuestion,
                (questionAnswer, evaluationAnswer) =>
                {
                    evaluationAnswer.Answers = questionAnswer.SelectedAnswersIds;
                    return true;
                }).ToArray();
        }
    }
}
