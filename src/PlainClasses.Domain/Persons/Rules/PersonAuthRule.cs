using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons.Rules
{
    public class PersonAuthRule : IBusinessRule
    {
        private readonly IEnumerable<PersonAuth> _personAuths;
        private readonly string _authName;

        public PersonAuthRule(IEnumerable<PersonAuth> personAuths, string authName)
        {
            _personAuths = personAuths;
            _authName = authName;
        }

        public bool IsBroken() => _personAuths.Any(x => x.AuthName == _authName);
        

        public string Message => "Person already has this permission.";
    }
}