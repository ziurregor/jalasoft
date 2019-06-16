namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Enums;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public static class Samples
    {
        static Samples()
        {
            Template = NewTemplate();
            Evaluation = NewEvaluation();
            EvaluationTemplate = NewEvaluationTemplate();
            CompleteEvaluation = NewCompleteEvaluation();
        }

        public static Template Template { get; set; }

        public static Evaluation Evaluation { get; set; }

        public static EvaluationScore EvaluationTemplate { get; set; }

        public static EvaluationScore CompleteEvaluation { get; set; }

        private static Template NewTemplate()
        {
            return new Template()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111110"),
                Name = "One to Many",
                ScoreFormula = "sum(i, 0, questionsLength, questionResult(i))",
                Body = new List<QuestionField>
                {
                    new QuestionField()
                    {
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                        Label = "Multiple Choice",
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        OptionRules = new ChoiceAnswerField()
                        {
                            OptionType = OptionType.Check
                        }
                    },
                    new QuestionField()
                    {
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                        Label = "Single Choice",
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        OptionRules = new ChoiceAnswerField()
                        {
                            OptionType = OptionType.Radio
                        }
                    }
                }
            };
        }

        private static Evaluation NewEvaluation()
        {
            return new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111120"),
                IdTemplate = Guid.Parse("11111111-1111-1111-1111-111111111110"),
                Name = "Test",
                QualificationRanges = new List<QualificationRange>
                {
                    new QualificationRange()
                    {
                        Id = Guid.Parse("c6739efc-de61-4bd5-9497-a4d6c070e03b"),
                        Start = 0,
                        End = 10,
                        Qualification = "Aproved"
                    },
                    new QualificationRange()
                    {
                        Id = Guid.Parse("394a2b46-c963-4e0d-83d5-c0c141b1ba7b"),
                        Start = 11,
                        End = 20,
                        Qualification = "Reproved"
                    }
                },
                Body = new List<Section>()
                {
                    new Section()
                    {
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111127"),
                        Sequence = 1,
                        Questions = new List<Question>()
                        {
                            new Question()
                            {
                                Id = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                                IdTemplateQuestionField = Template.Body[0].Id,
                                Weighted = false,
                                Weight = 10,
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                                        Sequence = 1,
                                        Weight = 10,
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                                        Sequence = 2,
                                        Weight = 0,
                                    }
                                }
                            },
                            new Question()
                            {
                                Id = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                                IdTemplateQuestionField = Template.Body[1].Id,
                                Weighted = false,
                                Weight = 10,
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                                        Sequence = 1,
                                        Weight = 5,
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                                        Sequence = 2,
                                        Weight = 5,
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        private static EvaluationScore NewEvaluationTemplate()
        {
            return new EvaluationScore()
            {
                IdEvaluation = Guid.Parse("11111111-1111-1111-1111-111111111120"),
                Name = "Test",
                ScoreFormula = Template.ScoreFormula,
                QuestionList = new List<QuestionScore>()
                {
                    new QuestionScore()
                    {
                        IdQuestion = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                        ScoreFormula = Template.Body[0].ScoreFormula,
                        Weight = Evaluation.Body[0].Questions[0].Weight,
                        Weighted = Evaluation.Body[0].Questions[0].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                                Sequence = Evaluation.Body[0].Questions[0].Options[0].Sequence,
                                Weight = Evaluation.Body[0].Questions[0].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                                Sequence = Evaluation.Body[0].Questions[0].Options[1].Sequence,
                                Weight = Evaluation.Body[0].Questions[0].Options[1].Weight
                            }
                        }
                    },
                    new QuestionScore()
                    {
                        IdQuestion = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                        ScoreFormula = Template.Body[0].ScoreFormula,
                        Weight = Evaluation.Body[0].Questions[1].Weight,
                        Weighted = Evaluation.Body[0].Questions[1].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                                Sequence = Evaluation.Body[0].Questions[1].Options[0].Sequence,
                                Weight = Evaluation.Body[0].Questions[1].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                                Sequence = Evaluation.Body[0].Questions[1].Options[1].Sequence,
                                Weight = Evaluation.Body[0].Questions[1].Options[1].Weight
                            }
                        }
                    }
                }
            };
        }

        private static EvaluationScore NewCompleteEvaluation()
        {
            return new EvaluationScore()
            {
                IdEvaluation = Evaluation.Id,
                Name = "Test",
                ScoreFormula = Template.ScoreFormula,
                QualificationRanges = new List<QualificationRange>
                {
                    new QualificationRange()
                    {
                        Id = Guid.Parse("c6739efc-de61-4bd5-9497-a4d6c070e03b"),
                        Start = 0,
                        End = 10,
                        Qualification = "Aproved"
                    },
                    new QualificationRange()
                    {
                        Id = Guid.Parse("394a2b46-c963-4e0d-83d5-c0c141b1ba7b"),
                        Start = 11,
                        End = 20,
                        Qualification = "Reproved"
                    }
                },
                QuestionList = new List<QuestionScore>()
                {
                    new QuestionScore()
                    {
                        IdQuestion = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                        ScoreFormula = Template.Body[0].ScoreFormula,
                        Weight = Evaluation.Body[0].Questions[0].Weight,
                        Weighted = Evaluation.Body[0].Questions[0].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                                Sequence = Evaluation.Body[0].Questions[0].Options[0].Sequence,
                                Weight = Evaluation.Body[0].Questions[0].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                                Sequence = Evaluation.Body[0].Questions[0].Options[1].Sequence,
                                Weight = Evaluation.Body[0].Questions[0].Options[1].Weight
                            }
                        },
                        Answers = new List<Guid>()
                        {
                            Guid.Parse("11111111-1111-1111-1111-111111111122"),
                        }
                    },
                    new QuestionScore()
                    {
                        IdQuestion = Guid.Parse("11111111-1111-1111-1111-111111111124"),
                        ScoreFormula = Template.Body[1].ScoreFormula,
                        Weight = Evaluation.Body[0].Questions[1].Weight,
                        Weighted = Evaluation.Body[0].Questions[1].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111125"),
                                Sequence = Evaluation.Body[0].Questions[1].Options[0].Sequence,
                                Weight = Evaluation.Body[0].Questions[1].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Guid.Parse("11111111-1111-1111-1111-111111111126"),
                                Sequence = Evaluation.Body[0].Questions[1].Options[1].Sequence,
                                Weight = Evaluation.Body[0].Questions[1].Options[1].Weight
                            }
                        },
                        Answers = new List<Guid>()
                        {
                            Guid.Parse("11111111-1111-1111-1111-111111111125"),
                        }
                    }
                }
            };
        }
    }
}
