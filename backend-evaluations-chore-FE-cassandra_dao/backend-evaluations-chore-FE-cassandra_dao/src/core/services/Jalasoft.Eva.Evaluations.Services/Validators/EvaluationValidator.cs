namespace Jalasoft.Eva.Evaluations.Services.Validators
{
    using System;
    using System.Text.RegularExpressions;
    using Jalasoft.Eva.Evaluations.Domain.Enums;
    using Jalasoft.Eva.Evaluations.Domain.Evaluations;
    using Jalasoft.Eva.Evaluations.Domain.Templates;
    using Jalasoft.Eva.Evaluations.Services.Exceptions;

    public static class EvaluationValidator
    {
        public static void ValidateText(Data item, DataField rules)
        {
            try
            {
                if (rules.Type == DataFieldType.Text)
                {
                    var value = (string)item.Value;
                    var headerTextRules = (TextField)rules;

                    if (headerTextRules.MinChar != 0)
                    {
                        if (value.Length == 0 || value == string.Empty)
                        {
                            throw new ValidationErrorServiceException("Header Text cannot have an empty string as a value.");
                        }
                        else if (value.Length < headerTextRules.MinChar)
                        {
                            throw new ValidationErrorServiceException("Validation fail, data text length should be longer or equal to the MinChar limit.");
                        }
                    }

                    if (value.Length > headerTextRules.MaxChar)
                    {
                        throw new ValidationErrorServiceException("Validation fail, data text length should be smaller or equal to the MaxChar limit.");
                    }
                    else if (!new Regex(headerTextRules.AllowedCharsRule).IsMatch(value))
                    {
                        throw new ValidationErrorServiceException("Validation fail, header item should only contain alphanumeric characters.");
                    }
                }
                else
                {
                    throw new ValidationErrorServiceException("Mismatched types");
                }
            }
            catch (ServiceException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Validate(Evaluation evaluation, Template template)
        {
            if (!new Regex(template.AllowedCharsRule).IsMatch(evaluation.Name))
            {
                throw new ValidationErrorServiceException("Validation fail, header item should only contain alphanumeric characters.");
            }

            if (template.ValueRequired)
            {
                if (evaluation.Name == null | evaluation.Name.Length == 0)
                {
                    throw new ValidationErrorServiceException($"Invalid evaluation name, must contain at least a character");
                }
            }

            if (evaluation.Name.Length > template.EvalNameMaxChars)
            {
                throw new ValidationErrorServiceException($"Invalid evaluation name, exceeded allowed length");
            }

            if (evaluation.Headers != null)
            {
                foreach (var header in evaluation.Headers)
                {
                    var rules = template.Headers.Find(templateHeader => templateHeader.Id == header.IdTemplateDataField);
                    if (rules == null)
                    {
                        throw new ValidationErrorServiceException($"Couldn't match a header IdTemplateDataField {header.IdTemplateDataField}");
                    }

                    switch (rules.Type)
                    {
                        case DataFieldType.Text:
                            ValidateText(header, rules);
                            break;
                        case DataFieldType.Time:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
