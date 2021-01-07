using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Rules
{
    public class PersonIsInPlatoonRule : IBusinessRule
    {
        private readonly IEnumerable<Person> _persons;
        private readonly Person _person;

        public PersonIsInPlatoonRule(IEnumerable<Person> persons, Person person)
        {
            _persons = persons;
            _person = person;
        } 
        
        public bool IsBroken() => _persons.Any(x => x.Id == _person.Id);

        public string Message => $"Person with id: {_person.Id} already is in platoon.";
    }
}