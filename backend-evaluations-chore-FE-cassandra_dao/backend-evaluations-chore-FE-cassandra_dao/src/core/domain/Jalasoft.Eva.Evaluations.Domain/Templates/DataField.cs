namespace Jalasoft.Eva.Evaluations.Domain.Templates
{
    using Jalasoft.Eva.Evaluations.Domain.Enums;

    public class DataField : Field
    {
        public DataField(DataFieldType type)
        {
            this.Type = type;
        }

        public DataFieldType Type { get; set; }
    }
}
