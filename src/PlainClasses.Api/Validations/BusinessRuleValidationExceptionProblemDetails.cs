using Microsoft.AspNetCore.Http;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Api.Validations
{
    public class BusinessRuleValidationExceptionProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Details;
            Type = "https://somedomain/business-rule-validation-error";
        }
    }
}