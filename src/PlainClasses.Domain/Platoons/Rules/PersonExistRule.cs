using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Rules
{
    public class PersonExistRule : IBusinessRule
    {
        private readonly Person _person;

        public PersonExistRule(Person person)
        {
            _person = person;
        }

        public bool IsBroken() => _person == null;

        public string Message => $"Person with id: {_person.Id} does not exist.";
    }
}