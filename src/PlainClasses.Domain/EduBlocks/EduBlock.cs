using System;
using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.EduBlocks.DomainServices;
using PlainClasses.Domain.EduBlocks.Enums;
using PlainClasses.Domain.EduBlocks.Events;
using PlainClasses.Domain.EduBlocks.Rules;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Platoons.Rules;
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

        public void UpdateEduBlockData(string remarks, string place, DateTime startEduBlock, DateTime endEduBlock)
        {
            if (Remarks != remarks)
            {
                Remarks = remarks;
            }

            if (Enum.IsDefined(typeof(Place), place) && Place.ToString() != place.ToUppercaseFirstInvariant())
            {
                Place = Enum.Parse<Place>(place);
            }

            if (StartEduBlock != startEduBlock)
            {
                StartEduBlock = startEduBlock;
            }

            if (EndEduBlock != endEduBlock)
            {
                EndEduBlock = endEduBlock;
            }
            
            AddDomainEvent(new EduBlockDataUpdatedEvent(Id));
        }

        public void AddPlatoonToEduBlock(Guid platoonId, IGetPlatoonForId getPlatoonForId)
        {
            var platoon = getPlatoonForId.Get(platoonId);
            CheckRule(new PlatoonExistsRule(platoon));
            CheckRule(new PlatoonIsInEduBlockRule(_platoons, platoon));

            _platoons.Add(PlatoonInEduBlock.AddPlatoonToEduBlock(Id, platoon.Id));
            
            AddDomainEvent(new PlatoonToEduBlockAddedEvent(Id, platoon.Id));
        }

        public void DeletePlatoonFromEduBlock(Guid platoonId, IGetPlatoonInEduBlockForId getPlatoonInEduBlockForId)
        {
            var platoon = getPlatoonInEduBlockForId.Get(platoonId, Id);
            CheckRule(new PlatoonDoesNotExistRule(platoon));
            CheckRule(new PlatoonExistsInEduBlockRule(_platoons, platoon.PlatoonId));
            
            _platoons.Remove(_platoons.Single(x => x.PlatoonId == platoon.PlatoonId));
            
            AddDomainEvent(new PlatoonFomEduBlockDeletedEvent(Id, platoon.Id));
        }

        public void AddFunctionForPerson(Guid personId, string function, IGetPersonForId getPersonForId)
        {
            CheckRule(new FunctionInEduBlockRule(function.ToUppercaseFirstInvariant()));
            var person = getPersonForId.Get(personId);
            CheckRule(new PersonExistRule(person));
            CheckRule(new PersonHasFunctionInEduBlockRule(_personFunctions, person));

            _personFunctions.Add(PersonFunction.CreateFunctionForPersonInEduBlock(personId, Id, function));
            
            AddDomainEvent(new PersonFunctionInEduBlockAddedEvent(personId, Id, function));
        }
        
        public void DeleteFunctionPerson(Guid functionId, IGetPersonFunctionForId getPersonFunctionForId)
        {
            var functionPerson = getPersonFunctionForId.Get(functionId);
            CheckRule(new FunctionPersonExistRule(functionPerson));
            CheckRule(new FunctionPersonExistsInEduBlockRule(_personFunctions, functionPerson.Id));
            
            _personFunctions.Remove(_personFunctions.Single(x => x.Id == functionPerson.Id));
            
            AddDomainEvent(new PersonFunctionFromEduBlockDeletedEvent(Id, functionId));
        }
        
        private void AddPlatoonToEduBlock(Platoon platoon)
        {
            _platoons.Add(PlatoonInEduBlock.AddPlatoonToEduBlock(Id, platoon.Id));
            
            AddDomainEvent(new PlatoonToEduBlockAddedEvent(Id, platoon.Id));
        }
    }
}