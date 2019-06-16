namespace Jalasoft.Eva.Evaluations.Domain.Templates
{
    using System.Collections.Generic;

    public class Template : Entity
    {
        public string Name { get; set; }

        public int EvalNameMaxChars { get; set; }

        public string AllowedCharsRule { get; set; }

        public bool ValueRequired { get; set; }

        public string ScoreFormula { get; set; }

        public Dictionary<string, object> QualificationRules { get; set; }

        public List<DataField> Headers { get; set; }

        public List<QuestionField> Body { get; set; }
    }
}
