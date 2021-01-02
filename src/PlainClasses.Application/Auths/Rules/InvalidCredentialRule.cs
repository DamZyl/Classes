using PlainClasses.Domain.Models;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Application.Auths.Rules
{
    public class InvalidCredentialRule : IBusinessRule
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly Person _person;
        private readonly string _requestPassword;

        public InvalidCredentialRule(IPasswordHasher passwordHasher, Person person, string requestPassword)
        {
            _passwordHasher = passwordHasher;
            _person = person;
            _requestPassword = requestPassword;
        }

        public bool IsBroken() => !(_person != null && _passwordHasher.Check(_person.Password, _requestPassword));

        public string Message => "Invalid credentials.";
    }
}