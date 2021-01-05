using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Dispatchers;

namespace PlainClasses.Application.Platoons.Queries.GetPlatoons
{
    public class GetPlatoonsQueryHandler : IQueryHandler<GetPlatoonsQuery, IEnumerable<PlatoonViewModel>>
    {
        public Task<IEnumerable<PlatoonViewModel>> Handle(GetPlatoonsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}