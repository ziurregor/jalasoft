namespace Jalasoft.Eva.Evaluations.Services.Impl.ScoreUtils
{
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public sealed class OptionListIterator : AbstractListIterator<OptionScore>
    {
        public OptionListIterator(List<OptionScore> options, string functionName)
            : base(options, functionName)
        {
        }

        public override double calculate()
        {
            if (this.Index >= 0 && this.Index < this.Values.Count)
            {
                return this.Values[this.Index].Weight;
            }
            else
            {
                return 0;
            }
        }
    }
}
