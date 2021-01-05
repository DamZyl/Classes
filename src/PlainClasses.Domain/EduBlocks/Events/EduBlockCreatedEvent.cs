using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Events
{
    public class EduBlockCreatedEvent : DomainEventBase
    {
        public Guid EduBlockId { get; private set; }

        public EduBlockCreatedEvent(Guid eduBlockId)
        {
            EduBlockId = eduBlockId;
        }
    }
}