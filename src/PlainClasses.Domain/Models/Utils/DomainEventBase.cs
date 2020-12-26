using System;

namespace PlainClasses.Domain.Models.Utils
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