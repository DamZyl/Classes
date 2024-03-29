using PlainClasses.Application.Persons.Queries.GetPerson;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Persons.Rules
{
    public class PersonExistRule : IBusinessRule
    {
        private readonly PersonViewModelDetail _person;

        public PersonExistRule(PersonViewModelDetail person)
        {
            _person = person;
        }

        public bool IsBroken() => _person == null;

        public string Message => $"Person with id: {_person.Id} does not exist.";
    }
}