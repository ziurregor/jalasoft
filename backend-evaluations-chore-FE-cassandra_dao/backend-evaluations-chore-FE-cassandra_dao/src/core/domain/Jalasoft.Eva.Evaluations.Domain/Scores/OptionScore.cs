namespace Jalasoft.Eva.Evaluations.Domain.Scores
{
    using System;

    public class OptionScore
    {
        public Guid IdOption { get; set; }

        public int Sequence { get; set; }

        public int Weight { get; set; }

        public bool UserSelected { get; set; }

        public bool IsAnswer { get; set; }
    }
}
