using System;
using System.Collections.Generic;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class Auth : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private ISet<PersonAuth> _personAuths = new HashSet<PersonAuth>();
        public IEnumerable<PersonAuth> PersonAuths => _personAuths;
    }
}