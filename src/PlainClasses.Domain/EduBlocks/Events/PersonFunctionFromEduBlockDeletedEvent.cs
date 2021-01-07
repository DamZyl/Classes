using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Events
{
    public class PersonFunctionFromEduBlockDeletedEvent : DomainEventBase
    {
        public Guid EduBlockId { get; private set; }
        public Guid FunctionId { get; private set; }

        public PersonFunctionFromEduBlockDeletedEvent(Guid eduBlockId, Guid functionId)
        {
            EduBlockId = eduBlockId;
            FunctionId = functionId;
        }
    }
}