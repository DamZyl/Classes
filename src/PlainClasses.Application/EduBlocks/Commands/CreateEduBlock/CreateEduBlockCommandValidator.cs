using System;
using System.Linq;
using FluentValidation;

namespace PlainClasses.Application.EduBlocks.Commands.CreateEduBlock
{
    public class CreateEduBlockCommandValidator : AbstractValidator<CreateEduBlockCommand>
    {
        public CreateEduBlockCommandValidator()
        {
            RuleFor(x => x.EduBlockSubjectId)
                .NotEmpty()
                .WithMessage("EduBlockSubjectId is empty.");

            RuleFor(x => x.StartEduBlock)
                .NotEmpty()
                .WithMessage("StartEduBlockDate is empty.");

            RuleFor(x => x.EndEduBlock)
                .NotEmpty()
                .WithMessage("EndEduBlockDate is empty.");
            
            RuleFor(c => new {c.StartEduBlock, c.EndEduBlock})
                .Must(x => IsDateValid(x.StartEduBlock, x.EndEduBlock))
                .WithMessage("Wrong dates.");
            
            RuleFor(x => x.Place)
                .NotEmpty()
                .WithMessage("Place is empty.");
            
            RuleFor(x => x.PlatoonIds)
                .Must(x => x.Any())
                .WithMessage("PlatoonIds is empty.");
        }

        private static bool IsDateValid(DateTime start, DateTime end)
        {
            if (start < DateTime.Now)
            {
                return false;
            }

            if (end < DateTime.Now)
            {
                return false;
            }

            return start < end;
        }
    }
}