using System;
using System.Collections.Generic;

namespace PlainClasses.Application.EduBlocks.Commands.CreateEduBlock
{
    public class CreateEduBlockRequest
    {
        public Guid EduBlockSubjectId { get; set; }
        public DateTime StartEduBlock { get; set; }
        public DateTime EndEduBlock { get; set; }
        public string Remarks { get; set; }
        public string Place { get; set; }
        public IEnumerable<Guid> PlatoonIds { get; set; }
    }
}