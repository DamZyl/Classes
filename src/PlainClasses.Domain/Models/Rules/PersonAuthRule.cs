using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
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

        public bool IsBroken() => _personAuths.All(x => x.AuthName != _authName);

        public string Message => "Person already has this permission.";
    }
}