using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Queries.GetEduBlock
{
    public class GetEduBlockQuery : IQuery<EduBlockDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}