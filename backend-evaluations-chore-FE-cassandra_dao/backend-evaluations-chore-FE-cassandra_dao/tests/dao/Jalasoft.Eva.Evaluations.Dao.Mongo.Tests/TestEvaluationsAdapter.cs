namespace Jalasoft.Eva.Evaluations.Dao.Mongo.Tests
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Dao.Mongo;
    using Jalasoft.Eva.Evaluations.Dao.Mongo.Adapters;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Xunit;

    public class TestEvaluationsAdapter
    {
        private EvaluationsAdapter mongoAdapter = new EvaluationsAdapter();

        [Fact]
        public void TestFromMongo()
        {
            var mongoEvaluation = new MongoEvaluation
            {
                PaginationId = default(MongoDB.Bson.ObjectId),
                Name = "New Evaluation",
                IdTemplate = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Body = new List<Section>()
                {
                    new Section()
                    {
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Text = "Does the candidate Apply TDD?",
                                Weight = 3,
                                IdTemplateQuestionField = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Sequence = 1,
                                        Text = "Often",
                                        Weight = 3
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var evaluation = this.mongoAdapter.FromMongo(mongoEvaluation);
            Assert.NotNull(evaluation);
        }

        [Fact]
        public void TestToMongo()
        {
            var evaluation = new Evaluation()
            {
                Name = "New Evaluation",
                IdTemplate = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Body = new List<Section>
                {
                    new Section()
                    {
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Text = "Does the candidate Apply TDD?",
                                Weight = 3,
                                IdTemplateQuestionField = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Sequence = 1,
                                        Text = "Often",
                                        Weight = 3
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var mongoEvaluation = this.mongoAdapter.ToMongo(evaluation);
            Assert.NotNull(mongoEvaluation);
        }
    }
}
