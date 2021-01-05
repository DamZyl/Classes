using System;
using System.Collections.Generic;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks
{
    public class EduBlockSubject : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private ISet<EduBlock> _eduBlocks = new HashSet<EduBlock>();
        public IEnumerable<EduBlock> EduBlocks => _eduBlocks;
    }
}