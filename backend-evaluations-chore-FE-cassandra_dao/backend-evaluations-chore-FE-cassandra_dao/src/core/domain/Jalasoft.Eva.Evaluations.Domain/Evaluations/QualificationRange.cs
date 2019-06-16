namespace Jalasoft.Eva.Evaluations.Domain.Evaluations
{
    public class QualificationRange : Entity
    {
        public int Start { get; set; }

        public int End { get; set; }

        public string Qualification { get; set; }
    }
}
