using PlainClasses.Application.Auths;
using PlainClasses.Domain.DomainServices;

namespace PlainClasses.Application.Persons.DomainServices
{
    public class PersonPasswordHasher : IPersonPasswordHasher
    {
        private readonly IPasswordHasher _passwordHasher;

        public PersonPasswordHasher(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }
        
        public string Hash(string password)
            => _passwordHasher.Hash(password);
    }
}