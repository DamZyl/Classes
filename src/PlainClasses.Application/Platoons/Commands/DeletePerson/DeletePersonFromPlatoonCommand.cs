using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Commands.DeletePerson
{
    public class DeletePersonFromPlatoonCommand : CommandBase
    {
        public Guid PlatoonId { get; }
        public Guid PersonId { get; }

        public DeletePersonFromPlatoonCommand(Guid platoonId, Guid personId)
        {
            PlatoonId = platoonId;
            PersonId = personId;
        }
    }
}