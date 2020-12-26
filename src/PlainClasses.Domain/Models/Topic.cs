using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class Topic : Entity
    {
        public Guid Id { get; set; }
        public EduBlockSubject EduBlockSubject { get; set; }
        public Guid EduBlockSubjectId { get; set; }
        public string Name { get; set; }
    }
}