namespace Jalasoft.Eva.Evaluations.Domain.Templates
{
    public class QuestionField : Field
    {
        public object OptionRules { get; set; }

        public string ScoreFormula { get; set; }

        public string AllowedCharsRule { get; set; }

        public bool ValueRequired { get; set; }

        public bool Weighted { get; set; }
    }
}
