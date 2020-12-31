using System;

namespace PlainClasses.Application.Persons.Queries.GetPersons
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string PersonalNumber { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlatoonAcr { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string Position { get; set; }
    }
}