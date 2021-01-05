using System;
using System.Collections.Generic;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models
{
    public class EduBlockSubject : Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private ISet<EduBlock> _eduBlocks = new HashSet<EduBlock>();
        public IEnumerable<EduBlock> EduBlocks => _eduBlocks;
    }
}