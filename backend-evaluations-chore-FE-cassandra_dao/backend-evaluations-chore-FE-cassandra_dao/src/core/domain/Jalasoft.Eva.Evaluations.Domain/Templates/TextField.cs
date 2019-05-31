namespace Jalasoft.Eva.Evaluations.Domain.Templates
{
    using Jalasoft.Eva.Evaluations.Domain.Enums;

    public class TextField : DataField
    {
        public TextField()
            : base(DataFieldType.Text)
        {
        }

        public string AllowedCharsRule { get; set; }

        public bool ValueRequired { get; set; }

        public bool Input { get; set; }

        public int MinChar { get; set; }

        public int MaxChar { get; set; }
    }
}
