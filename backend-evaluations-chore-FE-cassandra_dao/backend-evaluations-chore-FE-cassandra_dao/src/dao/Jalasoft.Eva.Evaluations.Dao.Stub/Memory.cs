namespace Jalasoft.Eva.Evaluations.Dao.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Domain.Enums;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Scores;
    using Jalasoft.Eva.Evaluations.Domain.Templates;

    public static class Memory
    {
        static Memory()
        {
            Evaluations = new MemoryRepository<Evaluation>();
            Templates = new MemoryRepository<Template>();
            Answers = new MemoryRepository<EvaluationScore>();

            AddEvaluationsSampleData();
            AddTemplatesSampleData();
            AddAnswersSampleData();
        }

        public static MemoryRepository<Evaluation> Evaluations { get; set; }

        public static MemoryRepository<Template> Templates { get; set; }

        public static MemoryRepository<EvaluationScore> Answers { get; set; }

        private static void AddEvaluationsSampleData()
        {
            Evaluations.List.Add(new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Ruben 360 Evaluation",
                CreationDate = DateTime.Parse("2018-12-13T19:40:18.5973309Z"),
                IdTemplate = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                EditDate = DateTime.Parse("2018-12-14T19:40:18.5973309Z"),
                Reply = "Thanks. We will contact you",
                QualificationRanges = new List<QualificationRange>
                {
                    new QualificationRange()
                    {
                        Id = Guid.Parse("c6739efc-de61-4bd5-9497-a4d6c070e03b"),
                        Start = 0,
                        End = 50,
                        Qualification = "Reproved"
                    },
                    new QualificationRange()
                    {
                        Id = Guid.Parse("394a2b46-c963-4e0d-83d5-c0c141b1ba7b"),
                        Start = 51,
                        End = 100,
                        Qualification = "Approved"
                    }
                },
                Headers = new List<Data>()
                {
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("36004a67-4c36-4457-a30f-617ca9e0c838"),
                        Value = "360 Evaluation"
                    },
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("e5e28a16-9a04-4834-b3e2-8298ab67d605"),
                        Value = "Within these questions you'll evaluate your teammate's performance in different areas."
                    },
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("eafdbb82-53b9-42b2-8bce-78af45106b8c"),
                        Value = 3600
                    }
                },
                Body = new List<Section>()
                {
                    new Section()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Best practices",
                        Description = "This section evaluates the best practices that the evaluated applies.",
                        Sequence = 1,
                        Questions = new List<Question>
                        {
                            new Question()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Does the candidate Apply TDD?",
                                Weight = 3,
                                Weighted = true,
                                IdTemplateQuestionField = Guid.NewGuid(),
                                Sequence = 1,
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 1,
                                        Text = "Often",
                                        Weight = 3
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 2,
                                        Text = "Sometimes",
                                        Weight = 2
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 3,
                                        Text = "Rarely",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 4,
                                        Text = "Never",
                                        Weight = 0
                                    }
                                }
                            },
                            new Question()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Which of the following practices does the candidate follow?",
                                Weight = 4,
                                Weighted = false,
                                IdTemplateQuestionField = Guid.NewGuid(),
                                Sequence = 2,
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 1,
                                        Text = "TDD",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 2,
                                        Text = "Code Styling",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 3,
                                        Text = "DDD",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 4,
                                        Text = "MVV",
                                        Weight = 1
                                    }
                                }
                            }
                        }
                    },
                    new Section()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Development",
                        Description = "This section evaluates the dev knowledge that the evaluated has.",
                        Sequence = 2,
                        Questions = new List<Question>
                        {
                            new Question()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Does the candidate apply unit tests?",
                                Weight = 3,
                                Weighted = true,
                                IdTemplateQuestionField = Guid.NewGuid(),
                                Sequence = 1,
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 1,
                                        Text = "Often",
                                        Weight = 3
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 2,
                                        Text = "Sometimes",
                                        Weight = 2
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 3,
                                        Text = "Rarely",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 4,
                                        Text = "Never",
                                        Weight = 0
                                    }
                                }
                            },
                            new Question()
                            {
                                Id = Guid.NewGuid(),
                                Text = "Which of the following patterns does the candidate know?",
                                Weight = 4,
                                Weighted = false,
                                IdTemplateQuestionField = Guid.NewGuid(),
                                Sequence = 2,
                                Options = new List<ChoiceAnswer>()
                                {
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 1,
                                        Text = "Repository Pattern",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 2,
                                        Text = "Façade",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 3,
                                        Text = "Singleton",
                                        Weight = 1
                                    },
                                    new ChoiceAnswer()
                                    {
                                        Id = Guid.NewGuid(),
                                        Sequence = 4,
                                        Text = "Decorator",
                                        Weight = 1
                                    }
                                }
                            }
                        }
                    }
                }
            });

            Evaluations.List.Add(new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Name = "Alvaro 360 Evaluation",
                CreationDate = DateTime.Now.ToUniversalTime(),
                EditDate = DateTime.Now.ToUniversalTime(),
                Reply = "Thanks. We will contact you",
                IdTemplate = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                QualificationRanges = new List<QualificationRange>
                {
                    new QualificationRange()
                    {
                        Id = Guid.Parse("c6739efc-de61-4bd5-9497-a4d6c070e03b"),
                        Start = 0,
                        End = 50,
                        Qualification = "Reproved"
                    },
                    new QualificationRange()
                    {
                        Id = Guid.Parse("394a2b46-c963-4e0d-83d5-c0c141b1ba7b"),
                        Start = 51,
                        End = 100,
                        Qualification = "Approved"
                    }
                },
                Headers = new List<Data>()
                {
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("36004a67-4c36-4457-a30f-617ca9e0c838"),
                        Value = "360 Evaluation"
                    },
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("e5e28a16-9a04-4834-b3e2-8298ab67d605"),
                        Value = "Within these questions you'll evaluate your teammate's performance in different areas."
                    },
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("eafdbb82-53b9-42b2-8bce-78af45106b8c"),
                        Value = 3600
                    }
                }
            });

            Evaluations.List.Add(new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                Name = "Grover 360 Evaluation",
                CreationDate = DateTime.Now.ToUniversalTime(),
                EditDate = DateTime.Now.ToUniversalTime(),
                Reply = "Thanks. We will contact you",
                IdTemplate = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                QualificationRanges = new List<QualificationRange>
                {
                    new QualificationRange()
                    {
                        Id = Guid.Parse("c6739efc-de61-4bd5-9497-a4d6c070e03b"),
                        Start = 0,
                        End = 50,
                        Qualification = "Aproved"
                    },
                    new QualificationRange()
                    {
                        Id = Guid.Parse("394a2b46-c963-4e0d-83d5-c0c141b1ba7b"),
                        Start = 51,
                        End = 100,
                        Qualification = "Reproved"
                    }
                },
                Headers = new List<Data>()
                {
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("36004a67-4c36-4457-a30f-617ca9e0c838"),
                        Value = "360 Evaluation"
                    },
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("e5e28a16-9a04-4834-b3e2-8298ab67d605"),
                        Value = "Within these questions you'll evaluate your teammate's performance in different areas."
                    },
                    new Data()
                    {
                        IdTemplateDataField = Guid.Parse("eafdbb82-53b9-42b2-8bce-78af45106b8c"),
                        Value = 3600
                    }
                }
            });
        }

        private static void AddTemplatesSampleData()
        {
            string templateRegEx = @"^(\s*[\w&!¡+\-\(\),.´*@\\/%#?¿'""_áéíóúÁÉÍÓÚÄËÏÖÜäëïöü]\s*)*$";
            Templates.List.Add(new Template()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                EvalNameMaxChars = 150,
                AllowedCharsRule = templateRegEx,
                ValueRequired = true,
                Name = "One to Many",
                ScoreFormula = "sum(i, 0, questionsLength, questionResult(i))",
                QualificationRules = new Dictionary<string, object>()
                {
                    { "Min", 0 },
                    { "MinRanges", 1 }
                },
                Headers = new List<DataField>
                {
                    new TextField()
                    {
                        Id = Guid.Parse("36004a67-4c36-4457-a30f-617ca9e0c838"),
                        Label = "Description",
                        Type = DataFieldType.Text,
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        Input = false,
                        MinChar = 0,
                        MaxChar = 150
                    }
                },
                Body = new List<QuestionField>
                {
                    new QuestionField()
                    {
                        Id = Guid.Parse("bdccdc7c-f397-4998-9efb-2ac2c9d40413"),
                        Label = "Single Choice",
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        ScoreFormula = "(correctAnswers / correctOptions) * questionScore",
                        Weighted = false,
                        OptionRules = new ChoiceAnswerField()
                        {
                            AllowedCharsRule = templateRegEx,
                            ValueRequired = true,
                            OptionType = OptionType.Radio,
                            MinOptions = 2,
                            MaxOptions = 7,
                        }
                    },
                    new QuestionField()
                    {
                        Id = Guid.Parse("5f4df704-8201-4e4f-94c2-4409da82bdb9"),
                        Label = "Single Choice With Weight",
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weighted = true,
                        OptionRules = new ChoiceAnswerField()
                        {
                            AllowedCharsRule = templateRegEx,
                            ValueRequired = true,
                            OptionType = OptionType.RadioWeight,
                            MinOptions = 2,
                            MaxOptions = 7,
                        }
                    },
                    new QuestionField()
                    {
                        Id = Guid.Parse("e2c7f8a4-a349-4381-bba7-ece43a4d3e7f"),
                        Label = "Multiple Choice",
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        ScoreFormula = "(correctAnswers / correctOptions) * questionScore",
                        Weighted = false,
                        OptionRules = new ChoiceAnswerField()
                        {
                            AllowedCharsRule = templateRegEx,
                            ValueRequired = true,
                            OptionType = OptionType.Check,
                            MinOptions = 2,
                            MaxOptions = 5,
                        }
                    },
                    new QuestionField()
                    {
                        Id = Guid.Parse("eafdbb82-53b9-42b2-8bce-78af45106b8c"),
                        Label = "Multiple Choice With Weight",
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weighted = true,
                        OptionRules = new ChoiceAnswerField()
                        {
                            AllowedCharsRule = templateRegEx,
                            ValueRequired = true,
                            OptionType = OptionType.CheckWeight,
                            MinOptions = 2,
                            MaxOptions = 5,
                        }
                    },
                }
            });

            Templates.List.Add(new Template()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                EvalNameMaxChars = 150,
                AllowedCharsRule = templateRegEx,
                ValueRequired = true,
                Name = "Many to One",
                QualificationRules = new Dictionary<string, object>()
                {
                    { "Min", 0 },
                    { "MinRanges", 1 }
                },
                Headers = new List<DataField>
                {
                    new TextField()
                    {
                        Id = Guid.Parse("36004a67-4c36-4457-a30f-617ca9e0c838"),
                        Label = "Description",
                        Type = DataFieldType.Text,
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        Input = false,
                        MinChar = 0,
                        MaxChar = 150
                    }
                },
                Body = new List<QuestionField>
                {
                    new QuestionField()
                    {
                        Id = Guid.Parse("5f4df704-8201-4e4f-94c2-4409da82bdb9"),
                        Label = "Single Choice With Weight",
                        AllowedCharsRule = templateRegEx,
                        ValueRequired = true,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weighted = true,
                        OptionRules = new ChoiceAnswerField()
                        {
                            AllowedCharsRule = templateRegEx,
                            ValueRequired = true,
                            OptionType = OptionType.RadioWeight,
                            MinOptions = 2,
                            MaxOptions = 7,
                        }
                    }
                }
            });
        }

        private static void AddAnswersSampleData()
        {
            Answers.List.Add(new EvaluationScore()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111666666"),
                IdEvaluation = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Test",
                ScoreFormula = "sum(i, 0, questionsLength, questionResult(i))",
                QuestionList = new List<QuestionScore>()
                {
                    new QuestionScore()
                    {
                        IdQuestion = Evaluations.List[0].Body[0].Id,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weight = Evaluations.List[0].Body[0].Questions[0].Weight,
                        Weighted = Evaluations.List[0].Body[0].Questions[0].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[0].Options[0].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[0].Options[0].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[0].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[0].Options[1].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[0].Options[1].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[0].Options[1].Weight
                            }
                        },
                        Answers = new List<Guid>()
                        {
                            Evaluations.List[0].Body[0].Questions[0].Options[0].Id
                        }
                    },
                    new QuestionScore()
                    {
                        IdQuestion = Evaluations.List[0].Body[0].Questions[1].Id,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weight = Evaluations.List[0].Body[0].Questions[1].Weight,
                        Weighted = Evaluations.List[0].Body[0].Questions[1].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[1].Options[0].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[1].Options[0].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[1].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[1].Options[1].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[1].Options[1].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[1].Options[1].Weight
                            }
                        },
                        Answers = new List<Guid>()
                        {
                            Evaluations.List[0].Body[0].Questions[1].Options[0].Id
                        }
                    }
                }
            });
            Answers.List.Add(new EvaluationScore()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111777777"),
                IdEvaluation = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Test",
                ScoreFormula = "sum(i, 0, questionsLength, questionResult(i))",
                QuestionList = new List<QuestionScore>()
                {
                    new QuestionScore()
                    {
                        IdQuestion = Evaluations.List[0].Body[0].Id,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weight = Evaluations.List[0].Body[0].Questions[0].Weight,
                        Weighted = Evaluations.List[0].Body[0].Questions[0].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[0].Options[0].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[0].Options[0].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[0].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[0].Options[1].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[0].Options[1].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[0].Options[1].Weight
                            }
                        },
                        Answers = new List<Guid>()
                        {
                            Evaluations.List[0].Body[0].Questions[0].Options[0].Id
                        }
                    },
                    new QuestionScore()
                    {
                        IdQuestion = Evaluations.List[0].Body[0].Questions[1].Id,
                        ScoreFormula = "sum(i, 0, correctAnswersLength, correctAnswer(i))",
                        Weight = Evaluations.List[0].Body[0].Questions[1].Weight,
                        Weighted = Evaluations.List[0].Body[0].Questions[1].Weighted,
                        OptionList = new List<OptionScore>()
                        {
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[1].Options[0].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[1].Options[0].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[1].Options[0].Weight
                            },
                            new OptionScore()
                            {
                                IdOption = Evaluations.List[0].Body[0].Questions[1].Options[1].Id,
                                Sequence = Evaluations.List[0].Body[0].Questions[1].Options[1].Sequence,
                                Weight = Evaluations.List[0].Body[0].Questions[1].Options[1].Weight
                            }
                        },
                        Answers = new List<Guid>()
                        {
                            Evaluations.List[0].Body[0].Questions[1].Options[0].Id
                        }
                    }
                }
            });
        }
    }
}