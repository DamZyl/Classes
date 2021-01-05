using System;

namespace PlainClasses.Domain.Utils.SharedKernels
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}