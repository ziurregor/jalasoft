namespace Jalasoft.Eva.Evaluations.Domain.Evaluations
{
    using System;
    using System.Collections.Generic;

    public class Evaluation : Entity
    {
        public string Name { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? EditDate { get; set; }

        public string Reply { get; set; }

        public Guid IdTemplate { get; set; }

        public List<QualificationRange> QualificationRanges { get; set; }

        public List<Data> Headers { get; set; }

        public List<Section> Body { get; set; }
    }
}
