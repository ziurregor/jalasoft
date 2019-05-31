namespace Jalasoft.Eva.Evaluations.Domain.Evaluations
{
    using System;
    using System.Collections.Generic;

    public class Question
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public List<ChoiceAnswer> Options { get; set; }

        public int Weight { get; set; }

        public Guid IdTemplateQuestionField { get; set; }

        public bool Weighted { get; set; }

        public int Sequence { get; set; }
    }
}
