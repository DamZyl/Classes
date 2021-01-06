using System;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Queries.GetPlatoon
{
    public class GetPlatoonQuery : IQuery<PlatoonDetailViewModel>
    {
        public Guid Id { get; set; }
    }
}