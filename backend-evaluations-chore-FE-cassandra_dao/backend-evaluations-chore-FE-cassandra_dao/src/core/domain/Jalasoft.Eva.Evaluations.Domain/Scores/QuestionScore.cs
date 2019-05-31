namespace Jalasoft.Eva.Evaluations.Domain.Scores
{
    using System;
    using System.Collections.Generic;

    public class QuestionScore
    {
        public Guid IdQuestion { get; set; }

        public bool Weighted { get; set; }

        public int Weight { get; set; }

        public double Score { get; set; }

        public string ScoreFormula { get; set; }

        public IList<OptionScore> OptionList { get; set; }

        public IList<Guid> Answers { get; set; }
    }
}
