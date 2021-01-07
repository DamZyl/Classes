using System;
using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Rules
{
    public class PersonExistsInPlatoonRule : IBusinessRule
    {
        private readonly IEnumerable<Person> _persons;
        private readonly Guid _personId;

        public PersonExistsInPlatoonRule(IEnumerable<Person> persons, Guid personId)
        {
            _persons = persons;
            _personId = personId;
        } 
        
        public bool IsBroken() => _persons.All(x => x.Id != _personId);

        public string Message => $"Person with id: {_personId} is not in platoon.";
    }
}