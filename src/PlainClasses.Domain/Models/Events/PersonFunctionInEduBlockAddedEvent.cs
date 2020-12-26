using System;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Events
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