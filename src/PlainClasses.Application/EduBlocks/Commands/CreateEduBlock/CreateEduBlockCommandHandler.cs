using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Domain.DomainServices;
using PlainClasses.Domain.Models;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.EduBlocks.Commands.CreateEduBlock
{
    public class CreateEduBlockCommandHandler : ICommandHandler<CreateEduBlockCommand, ReturnEduBlockViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetEduBlockSubjectForId _getEduBlockSubjectForId;
        private readonly IGetPlatoonsForIds _getPlatoonsForIds;

        public CreateEduBlockCommandHandler(IUnitOfWork unitOfWork, IGetEduBlockSubjectForId getEduBlockSubjectForId, 
            IGetPlatoonsForIds getPlatoonsForIds)
        {
            _unitOfWork = unitOfWork;
            _getEduBlockSubjectForId = getEduBlockSubjectForId;
            _getPlatoonsForIds = getPlatoonsForIds;
        }
        
        public async Task<ReturnEduBlockViewModel> Handle(CreateEduBlockCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = EduBlock.CreateEduBlock(request.EduBlockSubjectId, request.StartEduBlock, request.EndEduBlock, 
                request.Remarks, request.Place, request.PlatoonIds, _getEduBlockSubjectForId, _getPlatoonsForIds);

            await _unitOfWork.Repository<EduBlock>().AddAsync(eduBlock);
            await _unitOfWork.CommitAsync();

            return new ReturnEduBlockViewModel { Id = eduBlock.Id };
        }
    }
}