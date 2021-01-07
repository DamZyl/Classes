using System;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Commands.CreateEduBlock;

namespace PlainClasses.Application.EduBlocks.Commands.AddPlatoon
{
    public class AddPlatoonCommand : CommandBase<ReturnEduBlockViewModel>
    {
        public Guid EduBlockId { get; }
        public Guid PlatoonId { get; }

        public AddPlatoonCommand(Guid eduBlockId, Guid platoonId)
        {
            EduBlockId = eduBlockId;
            PlatoonId = platoonId;
        }
    }
}