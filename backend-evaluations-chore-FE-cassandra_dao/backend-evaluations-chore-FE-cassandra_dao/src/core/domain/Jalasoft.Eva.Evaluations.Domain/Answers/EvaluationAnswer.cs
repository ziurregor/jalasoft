namespace Jalasoft.Eva.Evaluations.Domain.Answers
{
    using System;
    using System.Collections.Generic;

    public class EvaluationAnswer : Entity
    {
        public Guid IdEvaluation { get; set; }

        public DateTime Date { get; set; }

        public double Score { get; set; }

        public string Owner { get; set; }

        public List<SectionAnswer> Sections { get; set; }
    }
}