using System;
using System.Collections.Generic;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.Persons.DomainServices;
using PlainClasses.Domain.Persons.Enums;
using PlainClasses.Domain.Persons.Events;
using PlainClasses.Domain.Persons.Rules;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.Extensions;
using PlainClasses.Domain.Utils.SharedKernels;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;
using PlainClasses.Domain.Utils.SharedKernels.Rules;

namespace PlainClasses.Domain.Persons
{
    public class Person : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string PersonalNumber { get; private set; }
        public Guid MilitaryRankId { get; private set; }
        public Guid? PlatoonId { get; private set; }
        public string MilitaryRankAcr { get; private set; }
        public string PlatoonAcr { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FatherName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string WorkPhoneNumber { get; private set; }
        public string PersonalPhoneNumber { get; private set; }
        public PersonPosition Position { get; private set; }
        private ISet<PersonAuth> _personAuths = new HashSet<PersonAuth>();
        public IEnumerable<PersonAuth> PersonAuths => _personAuths;
        private ISet<PersonFunction> _personFunctions = new HashSet<PersonFunction>();
        public IEnumerable<PersonFunction> PersonFunctions => _personFunctions;

        #region Ef_Config

        public MilitaryRank MilitaryRank { get; set; }
        public Platoon Platoon { get; set; }

        #endregion

        private Person() { }
        
        private Person(MilitaryRank militaryRank, Platoon platoon, string personalNumber, string password, string firstName, 
            string lastName, string fatherName, DateTime birthDate, string workPhoneNumber, string personalPhoneNumber, string position)
        {
            Id = Guid.NewGuid();
            PersonalNumber = personalNumber;
            MilitaryRankId = militaryRank.Id;
            PlatoonId = platoon.Id;
            MilitaryRankAcr = militaryRank.Acronym;
            PlatoonAcr = platoon.Acronym;
            Password = password;
            FirstName = firstName.ToUppercaseFirstInvariant();
            LastName = lastName.ToUppercaseFirstInvariant();
            FatherName = fatherName.ToUppercaseFirstInvariant();
            BirthDate = birthDate;
            WorkPhoneNumber = workPhoneNumber;
            PersonalPhoneNumber = personalPhoneNumber;
            Position = Enum.Parse<PersonPosition>(position.ToUppercaseFirstInvariant());
            
            AddDomainEvent(new PersonCreatedEvent(Id));
        }
        
        private Person(MilitaryRank militaryRank, string personalNumber, string password, string firstName, string lastName, 
            string fatherName, DateTime birthDate, string workPhoneNumber, string personalPhoneNumber, string position)
        {
            Id = Guid.NewGuid();
            PersonalNumber = personalNumber;
            MilitaryRankId = militaryRank.Id;
            MilitaryRankAcr = militaryRank.Acronym;
            Password = password;
            FirstName = firstName.ToUppercaseFirstInvariant();
            LastName = lastName.ToUppercaseFirstInvariant();
            FatherName = fatherName.ToUppercaseFirstInvariant();
            BirthDate = birthDate;
            WorkPhoneNumber = workPhoneNumber;
            PersonalPhoneNumber = personalPhoneNumber;
            Position = Enum.Parse<PersonPosition>(position.ToUppercaseFirstInvariant());
            
            AddDomainEvent(new PersonCreatedEvent(Id));
        }

        public static Person CreatePerson(Guid militaryRankId, Guid? platoonId, string personalNumber, string password, 
            string firstName, string lastName, string fatherName, DateTime birthDate, string workPhoneNumber, 
            string personalPhoneNumber, string position, IPersonPasswordHasher passwordHasher, 
            IGetMilitaryRankForId getMilitaryRankForId, IGetPlatoonForId getPlatoonForId)
        {
            var militaryRank = getMilitaryRankForId.Get(militaryRankId);
            CheckRule(new MilitaryRankExistRule(militaryRank));

            if (platoonId == null)
                return new Person(militaryRank, personalNumber, passwordHasher.Hash(password), firstName, lastName,
                    fatherName, birthDate, workPhoneNumber, personalPhoneNumber, position);
            
            var platoon = getPlatoonForId.Get((Guid)platoonId);
            CheckRule(new PlatoonExistsRule(platoon));
                
            return new Person(militaryRank, platoon, personalNumber, passwordHasher.Hash(password), firstName, lastName, 
                fatherName, birthDate, workPhoneNumber, personalPhoneNumber, position);
        }

        public void UpdatePersonalData(Guid militaryRankId, Guid? platoonId, string password, string lastName,
            string workPhoneNumber, string personalPhoneNumber, string position, IPersonPasswordHasher passwordHasher, 
            IGetMilitaryRankForId getMilitaryRankForId, IGetPlatoonForId getPlatoonForId)
        {
            var militaryRank = getMilitaryRankForId.Get(militaryRankId);
            CheckRule(new MilitaryRankExistRule(militaryRank));

            if (MilitaryRankId != militaryRankId)
            {
                MilitaryRankId = militaryRankId;
                MilitaryRankAcr = militaryRank.Acronym;
            }

            if (platoonId != null)
            {
                var platoon = getPlatoonForId.Get((Guid)platoonId);
                CheckRule(new PlatoonExistsRule(platoon));

                if (PlatoonId != platoonId)
                {
                    PlatoonId = platoonId;
                    PlatoonAcr = platoon.Acronym;
                }
            }

            if (!passwordHasher.Check(Password, password))
            {
                Password = passwordHasher.Hash(password);
            }

            if (LastName != lastName.ToUppercaseFirstInvariant())
            {
                LastName = lastName;
            }

            if (WorkPhoneNumber != workPhoneNumber)
            {
                WorkPhoneNumber = workPhoneNumber;
            }

            if (PersonalPhoneNumber != personalPhoneNumber)
            {
                PersonalPhoneNumber = personalPhoneNumber;
            }

            if (Enum.IsDefined(typeof(PersonPosition), position) && Position.ToString() != position.ToUppercaseFirstInvariant())
            {
                Position = Enum.Parse<PersonPosition>(position);
            }
            
            AddDomainEvent(new PersonDataUpdatedEvent(Id));
        }

        public void AddAuthToPerson(string authName) // Domain Service???
        {
            CheckRule(new PersonAuthRule(PersonAuths, authName));

            _personAuths.Add(PersonAuth.CreateAuthForPerson(Id, authName));
            
            AddDomainEvent(new PersonAuthAddedEvent(Id, authName));
        }
    }
}