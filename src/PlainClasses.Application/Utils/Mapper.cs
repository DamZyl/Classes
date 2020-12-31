using PlainClasses.Application.Persons.Queries.GetPersons;
using PlainClasses.Domain.Models;

namespace PlainClasses.Application.Utils
{
    public static class Mapper
    {
        public static PersonViewModel MapPersonToPersonViewModel(Person person)
            => new PersonViewModel
            {
                Id = person.Id,
                PersonalNumber = person.PersonalNumber,
                FullName = $"{person.MilitaryRankAcr} {person.FirstName} {person.LastName}",
                FatherName = person.FatherName,
                BirthDate = person.BirthDate,
                WorkPhoneNumber = person.WorkPhoneNumber,
                PersonalPhoneNumber = person.PersonalPhoneNumber,
                Position = person.Position.ToString(),
                PlatoonAcr = person.PlatoonAcr
            };
    }
}