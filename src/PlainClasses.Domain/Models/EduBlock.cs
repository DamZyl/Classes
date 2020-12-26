using System;
using System.Collections.Generic;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class EduBlock : Entity, IAggregateRoot
    {
        public Guid Id { get; set; }
        public EduBlockSubject EduBlockSubject { get; set; }
        public Guid EduBlockSubjectId { get; set; }
        public string EduBlockSubjectName { get; set; }
        public string Remarks { get; set; }
        public Place Place { get; set; }
        private ISet<PersonFunction> _personFunctions = new HashSet<PersonFunction>();
        public IEnumerable<PersonFunction> PersonFunctions => _personFunctions;
        private ISet<PlatoonInEduBlock> _platoons = new HashSet<PlatoonInEduBlock>();
        public IEnumerable<PlatoonInEduBlock> Platoons => _platoons;
    }
}