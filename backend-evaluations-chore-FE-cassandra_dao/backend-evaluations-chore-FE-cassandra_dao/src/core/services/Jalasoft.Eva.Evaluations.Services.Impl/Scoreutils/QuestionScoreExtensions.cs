namespace Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils
{
    using System.Linq;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public static class QuestionScoreExtensions
    {
        public static QuestionScore SetCorrectOptions(this QuestionScore question)
        {
            foreach (var option in question.OptionList)
            {
                if (option.Weight > 0)
                {
                    option.IsAnswer = true;
                }
            }

            return question;
        }

        public static QuestionScore SetUserSelectedOptions(this QuestionScore question)
        {
            question.OptionList.Join(
                question.Answers,
                option => option.IdOption,
                userAnswer => userAnswer,
                (option, userAnswer) =>
                {
                    option.UserSelected = true;
                    return true;
                }).ToArray();
            return question;
        }
    }
}
