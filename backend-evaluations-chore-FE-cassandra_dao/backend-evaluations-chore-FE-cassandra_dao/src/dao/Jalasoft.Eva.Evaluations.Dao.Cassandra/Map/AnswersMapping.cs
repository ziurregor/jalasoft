namespace Jalasoft.Eva.Evaluations.Dao.Cassandra.Map
{
    using global::Cassandra.Mapping;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public class AnswersMapping : Mappings
    {
        public AnswersMapping()
        {
            this.For<EvaluationScore>()
                .TableName("evaluation_score")
                .PartitionKey("evaluation_id", "id")
                .ClusteringKey("id")
                .Column(a => a.Id, cm => cm.WithName("id"))
                .Column(a => a.IdEvaluation, cm => cm.WithName("evaluation_id"))
                .Column(a => a.Date, cm => cm.WithName("date"))
                .Column(a => a.Owner, cm => cm.WithName("owner"))
                .Column(a => a.Name, cm => cm.WithName("name"))
                .Column(a => a.ScoreFormula, cm => cm.WithName("score_formula"))
                .Column(a => a.Score, cm => cm.WithName("score"))
                .Column(a => a.Weight, cm => cm.WithName("weight"))
                .Column(a => a.Qualification, cm => cm.WithName("qualification"))
                .Column(a => a.QuestionList, cm => cm.WithName("question_list"))
                .Column(a => a.QualificationRanges, cm => cm.WithName("qualification_ranges"))
                .ExplicitColumns();
        }
    }
}
