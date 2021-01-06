using System;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Events
{
    public class EduBlockDataUpdatedEvent : DomainEventBase
    {
        public Guid EduBlockId { get; private set; }

        public EduBlockDataUpdatedEvent(Guid eduBlockId)
        {
            EduBlockId = eduBlockId;
        }
    }
}