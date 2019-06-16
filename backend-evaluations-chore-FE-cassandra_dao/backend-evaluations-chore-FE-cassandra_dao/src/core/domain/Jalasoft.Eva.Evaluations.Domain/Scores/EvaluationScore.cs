namespace Jalasoft.Eva.Evaluations.Domain.Scores
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;

    public class EvaluationScore : Entity
    {
        public Guid IdEvaluation { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Owner { get; set; }

        public string Name { get; set; }

        public string ScoreFormula { get; set; }

        public double Score { get; set; }

        public int Weight { get; set; }

        public Guid Qualification { get; set; }

        public IEnumerable<QualificationRange> QualificationRanges { get; set; }

        public IEnumerable<QuestionScore> QuestionList { get; set; }
    }
}
