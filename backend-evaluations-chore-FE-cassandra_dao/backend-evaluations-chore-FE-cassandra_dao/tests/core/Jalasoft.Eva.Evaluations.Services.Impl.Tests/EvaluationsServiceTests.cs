namespace Jalasoft.Eva.Evaluations.Services.Impl.Tests
{
    using System;
    using System.Collections.Generic;
    using Jalasoft.Eva.Evaluations.Dao.Stub;
    using Jalasoft.Eva.Evaluations.Domain.Enums;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;
    using Jalasoft.Eva.Evaluations.Services.Impl.Tests.Helpers;
    using Xunit;

    public class EvaluationsServiceTests : IClassFixture<TestsFixture>
    {
        public EvaluationsServiceTests()
        {
            this.ValidationMockEvaluation = new Evaluation()
            {
                Name = "TestEval",
                IdTemplate = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                Headers = new List<Data>()
            };

            Memory.Templates.List.Add(new Template()
            {
                Id = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                EvalNameMaxChars = 150,
                AllowedCharsRule = @"^[\w\s]+$",
                ValueRequired = true,
                Name = "Evaluation Header Test Template",
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
            });
        }

        public Evaluation ValidationMockEvaluation { get; set; }

        [Fact]
        public void TestGetEvaluations()
        {
            var service = new EvaluationsService(new EvaluationsStubDao());
            var actual = service.GetEvaluations();

            Assert.NotNull(actual);
        }

        [Fact]
        public void TestGetEvaluation()
        {
            var service = new EvaluationsService(new EvaluationsStubDao());
            var actual = service.GetEvaluation(Guid.Parse("11111111-1111-1111-1111-111111111112"));

            Assert.NotNull(actual);
        }

        [Fact]
        public void TestDeleteEvaluation()
        {
            var service = new EvaluationsService(new EvaluationsStubDao());
            service.DeleteEvaluation(Guid.Parse("11111111-1111-1111-1111-111111111113"));
        }

        [Fact]
        public void TestDeleteNonExistingEvaluation_Throws_ItemNotFoundException()
        {
            var service = new EvaluationsService(new EvaluationsStubDao());

            Assert.Throws<ItemNotFoundServiceException>(() => service.DeleteEvaluation(Guid.Parse("f480b496-2356-402b-9fdc-a1893cc64e16")));
        }

        [Fact]
        public void TestDeleteNonExistingEvaluation_Throws_ItemNotFoundException_Message()
        {
            var expected = "Unable to find an evaluation with id f480b496-2356-402b-9fdc-a1893cc64e16";

            try
            {
                var service = new EvaluationsService(new EvaluationsStubDao());
                service.DeleteEvaluation(Guid.Parse("f480b496-2356-402b-9fdc-a1893cc64e16"));
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestUpdateEvaluation_Succesful_Update()
        {
            var service = new EvaluationsService(new EvaluationsStubDao());
            var evaluations = service.GetEvaluations();
            var actual = evaluations[0];
            var expected = new Evaluation { Id = actual.Id, Name = "Updated name" };

            service.UpdateEvaluation(expected);

            Assert.Equal(expected.Name, actual.Name);
        }

        [Fact]
        public void TestPostEvaluation()
        {
            Memory.Templates.List.Add(new Template()
            {
                Id = Guid.Parse("00000001-0000-0000-0000-000000000000"),
                EvalNameMaxChars = 150,
                AllowedCharsRule = @"^[\w\s]+$",
                ValueRequired = true,
                Name = "Evaluation Header Test Template",
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
            });
            var expected = new Evaluation()
            {
                Name = "New Evaluation",
                IdTemplate = Guid.Parse("00000001-0000-0000-0000-000000000000")
            };

            var service = new EvaluationsService(new EvaluationsStubDao());
            var actual = service.CreateEvaluation(expected);

            Assert.True(expected.Name == actual.Name);
        }

        [Fact]
        public void TestUpdateEvaluationWithCreationDate_Throws_InternalErrorDaoException()
        {
            var mockEvaluation = new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                Name = "New Evaluation",
                CreationDate = DateTime.Now
            };

            var expected = "Bad arguments, cannot update existing evaluation Creation Date";

            try
            {
                var service = new EvaluationsService(new EvaluationsStubDao());
                service.UpdateEvaluation(mockEvaluation);
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestUpdateEvaluationWithEditDate_Throws_InternalErrorDaoException()
        {
            var mockEvaluation = new Evaluation()
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                Name = "New Evaluation",
                EditDate = DateTime.Now
            };

            var expected = "Bad arguments, cannot update existing evaluation Edit Date";

            try
            {
                var service = new EvaluationsService(new EvaluationsStubDao());
                service.UpdateEvaluation(mockEvaluation);
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_EmptyString_Throws_Exception_Message()
        {
            var expected = "Header Text cannot have an empty string as a value.";

            try
            {
                this.ValidationMockEvaluation.Headers.Add(new Data()
                {
                    Value = string.Empty,
                    IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
                });

                var service = new EvaluationsService(new EvaluationsStubDao());
                service.CreateEvaluation(this.ValidationMockEvaluation);
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_EmptyString_Throws_Exception()
        {
            this.ValidationMockEvaluation.Headers.Add(new Data()
            {
                Value = string.Empty,
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
            });

            var service = new EvaluationsService(new EvaluationsStubDao());

            Assert.Throws<ValidationErrorServiceException>(() => service.CreateEvaluation(this.ValidationMockEvaluation));
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_MinCharViolation_Throws_Exception_Message()
        {
            var expected = "Validation fail, data text length should be longer or equal to the MinChar limit.";

            try
            {
                this.ValidationMockEvaluation.Headers.Add(new Data()
                {
                    Value = "123",
                    IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
                });

                var service = new EvaluationsService(new EvaluationsStubDao());
                service.CreateEvaluation(this.ValidationMockEvaluation);
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_MinCharViolation_Throws_Exception()
        {
            this.ValidationMockEvaluation.Headers.Add(new Data()
            {
                Value = "123",
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
            });

            var service = new EvaluationsService(new EvaluationsStubDao());

            Assert.Throws<ValidationErrorServiceException>(() => service.CreateEvaluation(this.ValidationMockEvaluation));
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_MaxCharViolation_Throws_Exception_Message()
        {
            var expected = "Validation fail, data text length should be smaller or equal to the MaxChar limit.";

            try
            {
                this.ValidationMockEvaluation.Headers.Add(new Data()
                {
                    Value = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901",
                    IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
                });

                var service = new EvaluationsService(new EvaluationsStubDao());
                service.CreateEvaluation(this.ValidationMockEvaluation);
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_MaxCharViolation_Throws_Exception()
        {
            this.ValidationMockEvaluation.Headers.Add(new Data()
            {
                Value = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901",
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
            });

            var service = new EvaluationsService(new EvaluationsStubDao());

            Assert.Throws<ValidationErrorServiceException>(() => service.CreateEvaluation(this.ValidationMockEvaluation));
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_IsAlphaNumeric_Throws_Exception_Message()
        {
            var expected = "Validation fail, header item should only contain alphanumeric characters.";

            try
            {
                this.ValidationMockEvaluation.Headers.Add(new Data()
                {
                    Value = "!@ThisIsATittle@!",
                    IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
                });

                var service = new EvaluationsService(new EvaluationsStubDao());
                service.CreateEvaluation(this.ValidationMockEvaluation);
            }
            catch (Exception e)
            {
                Assert.Equal(expected, e.Message);
            }
        }

        [Fact]
        public void TestCreateEvaluation_Header_Text_Value_IsAlphaNumeric_Throws_Exception()
        {
            this.ValidationMockEvaluation.Headers.Add(new Data()
            {
                Value = "!@ThisIsATittle@!",
                IdTemplateDataField = Guid.Parse("00000001-0001-0000-0000-000000000000")
            });

            var service = new EvaluationsService(new EvaluationsStubDao());

            Assert.Throws<ValidationErrorServiceException>(() => service.CreateEvaluation(this.ValidationMockEvaluation));
        }
    }
}