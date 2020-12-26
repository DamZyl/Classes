using System;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class PersonFunction : Entity
    {
        public Guid Id { get; set; }
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public EduBlock EduBlock { get; set; }
        public Guid EduBlockId { get; set; }
        public Function Function { get; set; }
    }
}