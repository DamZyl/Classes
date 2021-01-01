using PlainClasses.Application.EduBlocks.Queries.GetEduBlocks;
using PlainClasses.Application.Persons.Queries.GetPersons;
using PlainClasses.Application.Platoons.Queries.GetPlatoons;
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

        public static PlatoonViewModel MapPlatoonToPlatoonViewModel(Platoon platoon)
            => new PlatoonViewModel
                {
                    Id = platoon.Id,
                    Name = platoon.Name,
                    Acronym = platoon.Acronym,
                    Commander = platoon.Commander,
                    PersonCount = platoon.PersonCount
                };
        
        public static EduBlockViewModel MapEduBlockToEduBlockViewModel(EduBlock eduBlock)
            => new EduBlockViewModel
                {
                    Id = eduBlock.Id,
                    EduBlockSubjectName = eduBlock.EduBlockSubjectName,
                    StartEduBlock = eduBlock.StartEduBlock,
                    EndEduBlock = eduBlock.EndEduBlock,
                    Remarks = eduBlock.Remarks,
                    Place = eduBlock.Place.ToString()
                };
    }
}