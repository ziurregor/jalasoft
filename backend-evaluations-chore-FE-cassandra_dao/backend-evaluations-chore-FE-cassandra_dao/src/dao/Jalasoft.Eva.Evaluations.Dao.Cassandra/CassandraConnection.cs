namespace Jalasoft.Eva.Evaluations.Dao.Cassandra
{
    using System;
    using global::Cassandra;
    using global::Cassandra.Mapping;
    using Jalasoft.Eva.Evaluations.Dao.Cassandra.Map;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Scores;

    public class CassandraConnection : IConnectionFactory
    {
        private readonly string[] hosts;

        private readonly string keySpace;

        public CassandraConnection(string keySpace, params string[] hosts)
        {
            this.keySpace = keySpace;
            this.hosts = hosts;
            MappingConfiguration.Global.Define<AnswersMapping>();
        }

        public virtual ISession Session
        {
            get
            {
                var cluster = Cluster.Builder().AddContactPoints(this.hosts).Build();
                var session = cluster.Connect(this.keySpace);
                this.DefineUDTs(session);
                return session;
            }
        }

        public virtual IMapper GetMapper(ISession session)
        {
            return new Mapper(session);
        }

        private void DefineUDTs(ISession session)
        {
            session.UserDefinedTypes.Define(
                UdtMap.For<QualificationRange>("qualification_range")
                    .Map(qr => qr.Id, "id")
                    .Map(qr => qr.Start, "start")
                    .Map(qr => qr.End, "end")
                    .Map(qr => qr.Qualification, "qualification"),
                UdtMap.For<OptionScore>("option_score")
                    .Map(oc => oc.IdOption, "option_id")
                    .Map(oc => oc.Sequence, "sequence")
                    .Map(oc => oc.Weight, "weight")
                    .Map(oc => oc.UserSelected, "user_selected")
                    .Map(oc => oc.IsAnswer, "is_answer"),
                UdtMap.For<QuestionScore>("question_score")
                    .Map(qs => qs.IdQuestion, "question_id")
                    .Map(qs => qs.Weighted, "weighted")
                    .Map(qs => qs.Weight, "weight")
                    .Map(qs => qs.Score, "score")
                    .Map(qs => qs.ScoreFormula, "score_formula")
                    .Map(qs => qs.OptionList, "options_list")
                    .Map(qs => qs.Answers, "answers"));
        }
    }
}
