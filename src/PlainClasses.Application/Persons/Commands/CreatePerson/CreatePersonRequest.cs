using System;

namespace PlainClasses.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonRequest
    {
        public string PersonalNumber { get; set; }
        public Guid MilitaryRankId { get; set; }
        public Guid PlatoonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public string Position { get; set; }
    }
}