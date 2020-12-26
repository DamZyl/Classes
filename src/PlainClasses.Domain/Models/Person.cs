using System;
using System.Collections.Generic;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class Person : Entity, IAggregateRoot
    {
        public Guid Id { get; set; }
        public MilitaryRank MilitaryRank { get; set; }
        public Guid MilitaryRankId { get; set; }
        public Platoon Platoon { get; set; }
        public Guid PlatoonId { get; set; }
        public string MilitaryRankAcr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime BirthDate { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string PersonalPhoneNumber { get; set; }
        public PersonPosition Position { get; set; }
        private ISet<PersonAuth> _personAuths = new HashSet<PersonAuth>();
        public IEnumerable<PersonAuth> PersonAuths => _personAuths;
        private ISet<PersonFunction> _personFunctions = new HashSet<PersonFunction>();
        public IEnumerable<PersonFunction> PersonFunctions => _personFunctions;
    }
}