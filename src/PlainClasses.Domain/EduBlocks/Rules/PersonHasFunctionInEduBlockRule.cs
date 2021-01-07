using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class PersonHasFunctionInEduBlockRule : IBusinessRule
    {
        private readonly IEnumerable<PersonFunction> _personFunctions;
        private readonly Person _person;

        public PersonHasFunctionInEduBlockRule(IEnumerable<PersonFunction> personFunctions, Person person)
        {
            _personFunctions = personFunctions;
            _person = person;
        } 
        
        public bool IsBroken() => _personFunctions.Any(x => x.PersonId == _person.Id);

        public string Message => $"Person with id: {_person.Id} already has function in edu block.";
    }
}