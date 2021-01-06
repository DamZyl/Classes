﻿using System;
using System.Collections.Generic;
using PlainClasses.Domain.EduBlocks.DomainServices;
using PlainClasses.Domain.EduBlocks.Enums;
using PlainClasses.Domain.EduBlocks.Events;
using PlainClasses.Domain.EduBlocks.Rules;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.Extensions;
using PlainClasses.Domain.Utils.SharedKernels;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;
using PlainClasses.Domain.Utils.SharedKernels.Rules;

namespace PlainClasses.Domain.EduBlocks
{
    public class EduBlock : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public Guid EduBlockSubjectId { get; private set; }
        public string EduBlockSubjectName { get; private set; }
        public DateTime StartEduBlock { get; private set; }
        public DateTime EndEduBlock { get; private set; }
        public string Remarks { get; private set; }
        public Place Place { get; private set; }
        private ISet<PersonFunction> _personFunctions = new HashSet<PersonFunction>();
        public IEnumerable<PersonFunction> PersonFunctions => _personFunctions;
        private ISet<PlatoonInEduBlock> _platoons = new HashSet<PlatoonInEduBlock>();
        public IEnumerable<PlatoonInEduBlock> Platoons => _platoons;

        #region Ef_Config

        public EduBlockSubject EduBlockSubject { get; set; }

        #endregion

        private EduBlock() { }

        private EduBlock(EduBlockSubject eduBlockSubject, DateTime startEduBlock, DateTime endEduBlock, 
            string remarks, string place, IEnumerable<Platoon> platoons)
        {
            Id = Guid.NewGuid();
            EduBlockSubjectId = eduBlockSubject.Id;
            EduBlockSubjectName = eduBlockSubject.Name;
            StartEduBlock = startEduBlock;
            EndEduBlock = endEduBlock;
            Remarks = remarks;
            Place = Enum.Parse<Place>(place.ToUppercaseFirstInvariant());

            foreach (var platoon in platoons)
            {
                AddPlatoonToEduBlock(platoon);
            }
            
            AddDomainEvent(new EduBlockCreatedEvent(Id));
        }

        public static EduBlock CreateEduBlock(Guid eduBlockSubjectId, DateTime startEduBlock, DateTime endEduBlock, 
            string remarks, string place, IEnumerable<Guid> platoonIds, IGetEduBlockSubjectForId getEduBlockSubjectForId,
            IGetPlatoonsForIds getPlatoonsForIds)
        {
            var eduBlockSubject = getEduBlockSubjectForId.Get(eduBlockSubjectId);
            CheckRule(new EduBlockSubjectExistRule(eduBlockSubject));
            
            var platoons = getPlatoonsForIds.Get(platoonIds);
            CheckRule(new PlatoonsIdsCountEqualPlatoonsCount(platoonIds, platoons));
                
            return new EduBlock(eduBlockSubject, startEduBlock, endEduBlock, remarks, place, platoons);
        }

        public void AddPlatoonToEduBlock(Guid platoonId, IGetPlatoonForId getPlatoonForId)
        {
            var platoon = getPlatoonForId.Get(platoonId);
            CheckRule(new PlatoonExistRule(platoon));

            _platoons.Add(PlatoonInEduBlock.AddPlatoonToEduBlock(Id, platoon.Id));
            
            AddDomainEvent(new PlatoonToEduBlockAddedEvent(Id, platoon.Id));
        }
        
        private void AddPlatoonToEduBlock(Platoon platoon)
        {
            _platoons.Add(PlatoonInEduBlock.AddPlatoonToEduBlock(Id, platoon.Id));
            
            AddDomainEvent(new PlatoonToEduBlockAddedEvent(Id, platoon.Id));
        }
        
        
        public void AddFunctionForPerson(Guid personId, string function) // Domain Service???
        {
            // check exist edublock!!!
            // check function in this edublock

            _personFunctions.Add(PersonFunction.CreateFunctionForPersonInEduBlock(personId, Id, function));
            
            AddDomainEvent(new PersonFunctionInEduBlockAddedEvent(personId, Id, function));
        }
    }
}