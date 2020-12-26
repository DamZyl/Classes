using System;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class PlatoonInEduBlock : Entity
    {
        public Guid Id { get; set; }
        public Platoon Platoon { get; set; }
        public Guid PlatoonId { get; set; }
        public EduBlock EduBlock { get; set; }
        public Guid EduBlockId { get; set; }
    }
}