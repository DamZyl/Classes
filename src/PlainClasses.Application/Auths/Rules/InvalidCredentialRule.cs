using PlainClasses.Application.Auths.Commands.Login;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Auths.Rules
{
    public class InvalidCredentialRule : IBusinessRule
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly PersonDto _person;
        private readonly string _requestPassword;

        public InvalidCredentialRule(IPasswordHasher passwordHasher, PersonDto person, string requestPassword)
        {
            _passwordHasher = passwordHasher;
            _person = person;
            _requestPassword = requestPassword;
        }

        public bool IsBroken() => !(_person != null && _passwordHasher.Check(_person.Password, _requestPassword));

        public string Message => "Invalid credentials.";
    }
}