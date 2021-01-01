using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Dispatchers;

namespace PlainClasses.Application.EduBlocks.Queries.GetEduBlocks
{
    public class GetEduBlocksQueryHandler : IQueryHandler<GetEduBlocksQuery, IEnumerable<EduBlockViewModel>>
    {
        public Task<IEnumerable<EduBlockViewModel>> Handle(GetEduBlocksQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}