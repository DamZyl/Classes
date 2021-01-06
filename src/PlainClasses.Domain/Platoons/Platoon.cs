using System;
using System.Collections.Generic;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.Persons;
using PlainClasses.Domain.Platoons.Events;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons
{
    public class Platoon : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Acronym { get; private set; }
        public string Commander { get; private set; }
        public int PersonCount => _persons.Count;
        private ISet<Person> _persons = new HashSet<Person>();
        public IEnumerable<Person> Persons => _persons;
        private ISet<PlatoonInEduBlock> _platoons = new HashSet<PlatoonInEduBlock>();
        public IEnumerable<PlatoonInEduBlock> Platoons => _platoons;

        private Platoon() { }

        private Platoon(string name, string acronym, string commander)
        {
            Id = Guid.NewGuid();
            Name = name;
            Acronym = acronym;
            Commander = commander;
            
            AddDomainEvent(new PlatoonCreatedEvent(Id));
        }

        public static Platoon CreatePlatoon(string name, string acronym, string commander)
            => new Platoon(name, acronym, commander);

        public void AddPersonToPlatoon(Person person)
        {
            _persons.Add(person);
            
            AddDomainEvent(new PersonToPlatoonAddedEvent(Id, person.Id));
        }
    }
}