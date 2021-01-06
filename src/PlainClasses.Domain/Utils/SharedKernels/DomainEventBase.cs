using System;

namespace PlainClasses.Domain.Utils.SharedKernels
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }
    }
}