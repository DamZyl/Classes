using System;
using PlainClasses.Domain.EduBlocks.Enums;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Events
{
    public class PersonFunctionInEduBlockAddedEvent : DomainEventBase
    {
        public Guid PersonId { get; private set; }
        public Guid EduBlockId { get; private set; }
        public Function Function { get; private set; }

        public PersonFunctionInEduBlockAddedEvent(Guid personId, Guid eduBlockId, string function)
        {
            PersonId = personId;
            EduBlockId = eduBlockId;
            Function = Enum.Parse<Function>(function);
        }
    }
}