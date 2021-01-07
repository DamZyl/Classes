using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Commands.DeleteFunction
{
    public class DeleteFunctionCommand : CommandBase
    {
        public Guid EduBlockId { get; }
        public Guid FunctionId { get; }

        public DeleteFunctionCommand(Guid eduBlockId, Guid functionId)
        {
            EduBlockId = eduBlockId;
            FunctionId = functionId;
        }
    }
}