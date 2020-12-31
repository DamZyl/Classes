using System;
using PlainClasses.Application.Dispatchers;

namespace PlainClasses.Application.Persons.Commands.CreatePerson
{
    public class CreatePersonCommand : CommandBase<ReturnPersonViewModel>
    {
        public string PersonalNumber { get; }
        public Guid MilitaryRankId { get; }
        public Guid PlatoonId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string FatherName { get; }
        public DateTime BirthDate { get; }
        public string WorkPhoneNumber { get; }
        public string PersonalPhoneNumber { get; }
        public string Position { get; }

        public CreatePersonCommand(string personalNumber, Guid militaryRankId, Guid platoonId, string firstName, 
            string lastName, string fatherName, DateTime birthDate, string workPhoneNumber, string personalPhoneNumber, 
            string position) // Refactor To One Object!!!
        {
            PersonalNumber = personalNumber;
            MilitaryRankId = militaryRankId;
            PlatoonId = platoonId;
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            BirthDate = birthDate;
            WorkPhoneNumber = workPhoneNumber;
            PersonalPhoneNumber = personalPhoneNumber;
            Position = position;
        }
    }
}