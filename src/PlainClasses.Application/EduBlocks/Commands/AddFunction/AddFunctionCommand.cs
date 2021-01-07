using System;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Commands.CreateEduBlock;

namespace PlainClasses.Application.EduBlocks.Commands.AddFunction
{
    public class AddFunctionCommand : CommandBase<ReturnEduBlockViewModel>
    {
        public Guid EduBlockId { get; }
        public Guid PersonId { get; }
        public string Function { get; }

        public AddFunctionCommand(Guid eduBlockId, Guid personId, string function)
        {
            EduBlockId = eduBlockId;
            PersonId = personId;
            Function = function;
        }
    }
}