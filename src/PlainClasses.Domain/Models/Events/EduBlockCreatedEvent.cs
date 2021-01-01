using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
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