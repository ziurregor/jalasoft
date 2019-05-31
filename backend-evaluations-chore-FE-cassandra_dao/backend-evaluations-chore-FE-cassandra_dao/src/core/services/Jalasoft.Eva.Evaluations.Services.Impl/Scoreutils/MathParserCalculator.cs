namespace Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils
{
    using System.Collections.Generic;
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using org.mariuszgromada.math.mxparser;

    public class MathParserCalculator
    {
        public MathParserCalculator(EvaluationScore evaluation)
        {
            this.Evaluation = evaluation;
        }

        private EvaluationScore Evaluation { get; set; }

        private List<double> QuestionsScores { get; set; }

        public EvaluationScore Calculate()
        {
            this.CalculateQuestions();
            this.Evaluation.Score = this.GetEvaluationScore();
            this.Evaluation.Weight = this.GetTotalEvaluationWeight();
            return this.Evaluation;
        }

        public void CalculateQuestions()
        {
            foreach (var question in this.Evaluation.QuestionList)
            {
                question.SetUserSelectedOptions().SetCorrectOptions();
                var score = this.GetQuestionScore(question);
                question.Score = score;
            }
        }

        public double GetQuestionScore(QuestionScore question)
        {
            var variables = this.GetQuestionVariables(question);
            var expression = new Expression(question.ScoreFormula, variables);
            return expression.calculate();
        }

        public List<OptionScore> GetCorrectUserOptions(QuestionScore question)
        {
            List<OptionScore> userSelectedOptions = question.OptionList.Join(
                question.Answers,
                option => option.IdOption,
                answer => answer,
                (option, answer) =>
                {
                    return option;
                })
                .Where(option => option.Weight > 0)
                .ToList();
            return userSelectedOptions;
        }

        public double GetEvaluationScore()
        {
            var variables = this.GetEvaluationVariables();
            var expression = new Expression(this.Evaluation.ScoreFormula, variables);
            return expression.calculate();
        }

        public int GetTotalEvaluationWeight()
        {
            return this.Evaluation.QuestionList.Sum(question => question.Weight);
        }

        public List<OptionScore> GetCorrectQuestionOptions(QuestionScore question)
        {
            return question.OptionList.Where(option => option.IsAnswer).ToList();
        }

        private PrimitiveElement[] GetQuestionVariables(QuestionScore question)
        {
            var variables = new List<PrimitiveElement>();
            var correctUserOptions = this.GetCorrectUserOptions(question);
            var correctQuestionOptions = this.GetCorrectQuestionOptions(question);
            var answersIterator = new OptionListIterator(correctUserOptions, VariableNames.CorrectAnswer);
            variables.Add(new Argument(VariableNames.CorrectOptions, correctQuestionOptions.Count));
            variables.Add(new Argument(VariableNames.CorrectAnswers, correctUserOptions.Count));
            variables.Add(new Argument(VariableNames.CorrectAnswersLength, correctUserOptions.Count - 1));
            variables.Add(new Argument(VariableNames.QuestionScore, question.Weight));
            variables.Add(new Argument(VariableNames.OptionsLength, question.OptionList.Count - 1));
            variables.Add(new Function(VariableNames.CorrectAnswer, answersIterator));
            return variables.ToArray();
        }

        private PrimitiveElement[] GetEvaluationVariables()
        {
            var variables = new List<PrimitiveElement>();
            var questions = this.Evaluation.QuestionList.ToList();
            var questionIterator = new QuestionListIterator(questions, VariableNames.QuestionResult);
            variables.Add(new Function(VariableNames.QuestionResult, questionIterator));
            variables.Add(new Argument(VariableNames.QuestionLength, questions.Count - 1));
            variables.Add(new Argument(VariableNames.EvaluationTotalScore, this.GetTotalEvaluationWeight()));
            return variables.ToArray();
        }
    }
}
