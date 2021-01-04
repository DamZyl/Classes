using System;
using System.Collections.Generic;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Extensions;
using PlainClasses.Domain.Models.Enums;
using PlainClasses.Domain.Models.Events;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
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
                AddPlatoonToEduBlock(platoon.Id);
            }
            
            AddDomainEvent(new EduBlockCreatedEvent(Id));
        }

        public static EduBlock CreateEduBlock(Guid eduBlockSubjectId, DateTime startEduBlock, DateTime endEduBlock, 
            string remarks, string place, IEnumerable<Guid> platoonIds, IGetEduBlockSubjectForId getEduBlockSubjectForId,
            IGetPlatoonsForIds getPlatoonsForIds)
        {
            // check rule!!!

            var eduBlockSubject = getEduBlockSubjectForId.Get(eduBlockSubjectId);
            var platoons = getPlatoonsForIds.Get(platoonIds);
                
            return new EduBlock(eduBlockSubject, startEduBlock, endEduBlock, remarks, place, platoons);
        }

        public void AddPlatoonToEduBlock(Guid platoonId)
        {
            // check rule!!!

            _platoons.Add(PlatoonInEduBlock.AddPlatoonToEduBlock(Id, platoonId));
            
            AddDomainEvent(new PlatoonToEduBlockAddedEvent(Id, platoonId));
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