using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons.Rules
{
    public class PersonAuthExistRule : IBusinessRule
    {
        private readonly PersonAuth _personAuth;

        public PersonAuthExistRule(PersonAuth personAuth)
        {
            _personAuth = personAuth;
        }

        public bool IsBroken() => _personAuth == null;

        public string Message => $"Person auth with id: {_personAuth.Id} does not exist.";
    }
}