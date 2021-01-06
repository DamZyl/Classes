using System.Collections.Generic;
using PlainClasses.Application.Persons.Queries.GetPersons;

namespace PlainClasses.Application.Persons.Queries.GetPerson
{
    public class PersonViewModelDetail : PersonViewModel
    {
        public List<AuthViewModel> PersonAuths { get; set; }
    }
}