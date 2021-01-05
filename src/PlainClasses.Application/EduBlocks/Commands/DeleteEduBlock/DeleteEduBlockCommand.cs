using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Commands.DeleteEduBlock
{
    public class DeleteEduBlockCommand : CommandBase
    {
        public Guid EduBlockId { get; set; }
    }
}