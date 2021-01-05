using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Persons.Rules
{
    public class PersonDoesNotExistRule : IBusinessRule
    {
        private readonly Person _person;

        public PersonDoesNotExistRule(Person person)
        {
            _person = person;
        }

        public bool IsBroken() => _person == null;

        public string Message => $"Person with id: {_person.Id} does not exist.";
    }
}