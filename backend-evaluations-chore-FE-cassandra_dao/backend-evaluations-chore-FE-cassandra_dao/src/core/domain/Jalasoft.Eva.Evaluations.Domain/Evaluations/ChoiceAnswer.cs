namespace Jalasoft.Eva.Evaluations.Domain.Evaluations
{
    using System;

    public class ChoiceAnswer
    {
        public Guid Id { get; set; }

        public int Sequence { get; set; }

        public string Text { get; set; }

        public int Weight { get; set; }
    }
}
