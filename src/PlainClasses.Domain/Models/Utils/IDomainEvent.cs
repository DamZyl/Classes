using System;

namespace PlainClasses.Domain.Models.Utils
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}