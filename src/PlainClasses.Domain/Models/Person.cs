﻿using System;
using System.Collections.Generic;
using PlainClasses.Domain.DomainServices;
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
        
        private Person(Guid militaryRankId, string militaryRankAcronym, Guid platoonId, string platoonAcronym, string personalNumber, 
            string password, string firstName, string lastName, string fatherName, DateTime birthDate, string workPhoneNumber, 
            string personalPhoneNumber, string position)
        {
            Id = Guid.NewGuid();
            PersonalNumber = personalNumber;
            MilitaryRankId = militaryRankId;
            PlatoonId = platoonId;
            MilitaryRankAcr = militaryRankAcronym;
            PlatoonAcr = platoonAcronym;
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

        public static Person CreatePerson(Guid militaryRankId, string militaryRankAcronym, Guid platoonId, string platoonAcronym, 
            string personalNumber, string password, string firstName, string lastName, string fatherName, DateTime birthDate, 
            string workPhoneNumber, string personalPhoneNumber, string position, IPersonPasswordHasher passwordHasher)
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
            
            return new Person(militaryRankId, militaryRankAcronym, platoonId, platoonAcronym, personalNumber, 
                passwordHasher.Hash(password), firstName, lastName, fatherName, birthDate, workPhoneNumber, 
                personalPhoneNumber, position);
        }

        public void AddAuthToPerson(string authName) // Domain Service???
        {
            CheckRule(new PersonAuthRule(PersonAuths, authName));

            _personAuths.Add(PersonAuth.CreateAuthForPerson(Id, authName));
            
            AddDomainEvent(new PersonAuthAddedEvent(Id, authName));
        }
    }
}