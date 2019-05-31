namespace Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils
{
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public sealed class QuestionListIterator : AbstractListIterator<QuestionScore>
    {
        public QuestionListIterator(IList<QuestionScore> questions, string functionName)
            : base(questions, functionName)
        {
        }

        public override double calculate()
        {
            return this.Values[this.Index].Score;
        }
    }
}
