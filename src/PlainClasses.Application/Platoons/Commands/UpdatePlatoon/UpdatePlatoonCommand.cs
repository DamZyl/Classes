using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Commands.UpdatePlatoon
{
    public class UpdatePlatoonCommand : CommandBase
    {
        public Guid PlatoonId { get; set; }
        public string Commander { get; }

        public UpdatePlatoonCommand(Guid platoonId, string commander)
        {
            PlatoonId = platoonId;
            Commander = commander;
        }
    }
}