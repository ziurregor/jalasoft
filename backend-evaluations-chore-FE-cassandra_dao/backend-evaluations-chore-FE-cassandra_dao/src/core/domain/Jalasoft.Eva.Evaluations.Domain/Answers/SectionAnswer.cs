namespace Jalasoft.Eva.Evaluations.Domain.Answers
{
    using System.Collections.Generic;

    public class SectionAnswer : Entity
    {
        public List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
