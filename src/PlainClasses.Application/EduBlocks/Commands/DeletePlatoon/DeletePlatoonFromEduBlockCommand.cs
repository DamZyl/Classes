using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Commands.DeletePlatoon
{
    public class DeletePlatoonFromEduBlockCommand : CommandBase
    {
        public Guid EduBlockId { get; }
        public Guid PlatoonId { get; }

        public DeletePlatoonFromEduBlockCommand(Guid eduBlockId, Guid platoonId)
        {
            EduBlockId = eduBlockId;
            PlatoonId = platoonId;
        }
    }
}