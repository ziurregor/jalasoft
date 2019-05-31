namespace Jalasoft.Eva.Evaluations.Domain.Evaluations
{
    using System;
    using System.Collections.Generic;

    public class Section
    {
        public Guid Id { get; set; }

        public int Sequence { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Question> Questions { get; set; }
    }
}
