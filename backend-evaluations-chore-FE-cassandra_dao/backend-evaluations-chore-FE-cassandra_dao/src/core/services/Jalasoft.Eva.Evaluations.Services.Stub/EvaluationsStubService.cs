namespace Jalasoft.Eva.Evaluations.Services.Stub
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Core.Configurator;
    using Jalasoft.Eva.Core.Logger;
    using Jalasoft.Eva.Evaluations.Domain;
    using Jalasoft.Eva.Evaluations.Domain.Enums;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Jalasoft.Eva.Evaluations.Services;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Jalasoft.Eva.Evaluations.Services.Validators;

    public class EvaluationsStubService : IEvaluationsService, IRegistrableFactory<IEvaluationsService>
    {
        private static readonly ILogger Log = LoggerFactory.GetLogger(typeof(EvaluationsStubService));

        public IEvaluationsService CreateInstance()
        {
            return new EvaluationsStubService();
        }

        public IList<Evaluation> GetEvaluations()
        {
            var evaluation = new List<Evaluation>();
            evaluation.Add(new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Ruben 360 Evaluation",
            });

            evaluation.Add(new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                Name = "Alvaro 360 Evaluation",
            });

            evaluation.Add(new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                Name = "Grover 360 Evaluation",
            });

            return evaluation;
        }

        public PaginatedList<Evaluation> GetEvaluations(QueryParameters queryParameters)
        {
            var evaluations = this.GetEvaluations();
            return new PaginatedList<Evaluation>(evaluations, evaluations.Count);
        }

        public Evaluation GetEvaluation(Guid id)
        {
            var evaluation = new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                Name = "Ruben 360 Evaluation",
            };

            return evaluation;
        }

        public void DeleteEvaluation(Guid id)
        {
            return;
        }

        public Evaluation CreateEvaluation(Evaluation evaluation)
        {
            var template = new Template()
            {
                Id = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                EvalNameMaxChars = 150,
                AllowedCharsRule = @"^[\w\s]+$",
                ValueRequired = true,
                Name = "Evaluation Header Test Template",
                ScoreFormula = "sum(i, 0, questionsLength, questionScore(i))",
                Headers = new List<DataField>
                {
                    new TextField()
                    {
                        Id = Guid.Parse("00000001-0001-0000-0000-000000000000"),
                        AllowedCharsRule = @"^[\w\s]+$",
                        ValueRequired = true,
                        Input = false,
                        Label = "Title",
                        Type = DataFieldType.Text,
                        MinChar = 4,
                        MaxChar = 150
                    }
                }
            };

            try
            {
                EvaluationValidator.Validate(evaluation, template);
                return evaluation;
            }
            catch (ValidationErrorServiceException)
            {
                throw;
            }
        }

        public void UpdateEvaluation(Evaluation evaluation)
        {
            try
            {
                Log.Info(string.Format("Evaluation {0} is being updated", evaluation.Id));

                if (evaluation.CreationDate != null)
                {
                    throw new InvalidItemServiceException("Bad arguments, cannot update existing evaluation Creation Date");
                }
                else if (evaluation.EditDate != null)
                {
                    throw new InvalidItemServiceException("Bad arguments, cannot update existing evaluation Edit Date");
                }

                return;
            }
            catch (InvalidItemServiceException invalidItemServiceEx)
            {
                throw new InvalidItemServiceException(invalidItemServiceEx.Message, invalidItemServiceEx);
            }
        }
    }
}