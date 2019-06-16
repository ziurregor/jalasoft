namespace Jalasoft.Eva.Evaluations.Domain.Templates
{
    using Jalasoft.Eva.Evaluations.Domain.Enums;

    public class TimeField : DataField
    {
        public TimeField()
            : base(DataFieldType.Time)
        {
        }

        public int MinTime { get; set; }

        public int MaxTime { get; set; }
    }
}
