using System;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Platoons.Commands.CreatePlatoon;

namespace PlainClasses.Application.Platoons.Commands.AddPerson
{
    public class AddPersonCommand : CommandBase<ReturnPlatoonViewModel>
    {
        public Guid PlatoonId { get; set; }
        public Guid PersonId { get; set; }

        public AddPersonCommand(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}