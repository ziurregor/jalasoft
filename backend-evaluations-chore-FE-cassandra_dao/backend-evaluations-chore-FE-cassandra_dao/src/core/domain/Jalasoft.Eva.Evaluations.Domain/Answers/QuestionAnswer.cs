namespace Jalasoft.Eva.Evaluations.Domain.Answers
{
    using System;
    using System.Collections.Generic;

    public class QuestionAnswer : Entity
    {
        public Guid IdQuestion { get; set; }

        public double Score { get; set; }

        public List<Guid> SelectedAnswersIds { get; set; }
    }
}