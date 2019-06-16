namespace Jalasoft.Eva.Evaluations.Domain.Templates
{
    using Eva.Evaluations.Domain.Enums;

    public class OptionRules
    {
        public OptionType OptionType { get; set; }

        public string AllowedCharsRule { get; set; }

        public bool ValueRequired { get; set; }
    }
}
