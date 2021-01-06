using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Commands.DeletePlatoon
{
    public class DeletePlatoonCommand : CommandBase
    {
        public Guid PlatoonId { get; set; }

        public DeletePlatoonCommand(Guid platoonId)
        {
            PlatoonId = platoonId;
        }
    }
}