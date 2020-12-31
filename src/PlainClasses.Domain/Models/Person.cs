using System;
using System.Collections.Generic;
using PlainClasses.Domain.Extensions;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Events;
using PlainClasses.Domain.Models.Rules;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class Person : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string PersonalNumber { get; private set; }
        public Guid MilitaryRankId { get; private set; }
        public Guid PlatoonId { get; private set; }
        public string MilitaryRankAcr { get; private set; }
        public string PlatoonAcr { get; private set; }
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
        
        private Person(MilitaryRank militaryRank, Platoon platoon, string personalNumber, string firstName, string lastName, 
            string fatherName, DateTime birthDate, string workPhoneNumber, string personalPhoneNumber, string position)
        {
            Id = Guid.NewGuid();
            PersonalNumber = personalNumber;
            MilitaryRankId = militaryRank.Id;
            PlatoonId = platoon.Id;
            MilitaryRankAcr = militaryRank.Acronym;
            PlatoonAcr = platoon.Acronym;
            FirstName = firstName.ToUppercaseFirstInvariant();
            LastName = lastName.ToUppercaseFirstInvariant();
            FatherName = fatherName.ToUppercaseFirstInvariant();
            BirthDate = birthDate;
            WorkPhoneNumber = workPhoneNumber;
            PersonalPhoneNumber = personalPhoneNumber;
            Position = Enum.Parse<PersonPosition>(position.ToUppercaseFirstInvariant());
            
            AddDomainEvent(new PersonCreatedEvent(Id));
        }

        public static Person CreatePerson(MilitaryRank militaryRank, Platoon platoon, string personalNumber, string firstName, 
            string lastName, string fatherName, DateTime birthDate, string workPhoneNumber, string personalPhoneNumber, string position)
        {
            // CheckRule(new PersonalNumberValidRule(personalNumber));   
            // CheckRule(new EmptyFieldRule(firstName));
            // CheckRule(new EmptyFieldRule(lastName));
            // CheckRule(new EmptyFieldRule(fatherName));
            // CheckRule(new OverEighteenRule(birthDate));
            // CheckRule(new EmptyFieldRule(workPhoneNumber));
            // CheckRule(new NumberFormatRule(workPhoneNumber));
            // CheckRule(new EmptyFieldRule(personalPhoneNumber));
            // CheckRule(new NumberFormatRule(personalPhoneNumber));
            // CheckRule(new PersonPositionRule(position));
            
            return new Person(militaryRank, platoon, personalNumber, firstName, lastName, fatherName, birthDate, 
                workPhoneNumber, personalPhoneNumber, position);
        }

        public void AddAuthToPerson(Guid authId) // Domain Service???
        {
            CheckRule(new PersonAuthRule(PersonAuths, authId));

            _personAuths.Add(PersonAuth.CreateAuthForPerson(Id, authId));
            
            AddDomainEvent(new PersonAuthAddedEvent(Id, authId));
        }

        public void AddFunctionForPerson(Guid eduBlockId, string function) // Domain Service???
        {
            // check exist edublock!!!
            // check function in this edublock

            _personFunctions.Add(PersonFunction.CreateFunctionForPersonInEduBlock(Id, eduBlockId, function));
            
            AddDomainEvent(new PersonFunctionInEduBlockAddedEvent(Id, eduBlockId, function));
        }
    }
}