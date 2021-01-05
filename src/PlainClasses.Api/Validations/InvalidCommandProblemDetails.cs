using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlainClasses.Application.Configurations.Validation;

namespace PlainClasses.Api.Validations
{
    public class InvalidCommandProblemDetails : ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Details;
            Type = "https://somedomain/validation-error";
        }
    }
}