using PlainClasses.Application.Auths.Commands.Login;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Auths.Rules
{
    public class PersonDoesNotExistRule : IBusinessRule
    {
        private readonly PersonDto _personDto;

        public PersonDoesNotExistRule(PersonDto personDto)
        {
            _personDto = personDto;
        }

        public bool IsBroken() => _personDto == null;

        public string Message => $"Person with personal number: {_personDto.PersonalNumber} does not exist.";
    }
}