using System;
using System.Collections.Generic;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Persons
{
    public class MilitaryRank : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        private ISet<Person> _persons = new HashSet<Person>();
        public IEnumerable<Person> Persons => _persons;
    }
}