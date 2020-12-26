using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class PersonAuth : Entity
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public Auth Auth { get; set; }
        public Guid AuthId { get; set; }
    }
}