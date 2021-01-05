using System;
using System.Collections.Generic;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Commands.CreateEduBlock
{
    public class CreateEduBlockCommand : CommandBase<ReturnEduBlockViewModel>
    {
        public Guid EduBlockSubjectId { get; }
        public DateTime StartEduBlock { get; }
        public DateTime EndEduBlock { get; }
        public string Remarks { get; }
        public string Place { get; }
        public IEnumerable<Guid> PlatoonIds { get; }

        public CreateEduBlockCommand(Guid eduBlockSubjectId, DateTime startEduBlock, DateTime endEduBlock, string remarks, string place, IEnumerable<Guid> platoonIds)
        {
            EduBlockSubjectId = eduBlockSubjectId;
            StartEduBlock = startEduBlock;
            EndEduBlock = endEduBlock;
            Remarks = remarks;
            Place = place;
            PlatoonIds = platoonIds;
        }
    }
}