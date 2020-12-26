using System;
using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
{
    public class PersonAuthRule : IBusinessRule
    {
        private readonly IEnumerable<PersonAuth> _personAuths;
        private readonly Guid _authId;

        public PersonAuthRule(IEnumerable<PersonAuth> personAuths, Guid authId)
        {
            _personAuths = personAuths;
            _authId = authId;
        }

        public bool IsBroken() => _personAuths.All(x => x.AuthId != _authId);

        public string Message => "Person already has this permission.";
    }
}