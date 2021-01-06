using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.EduBlocks.Commands.UpdateEduBlock
{
    public class UpdateEduBlockCommandHandler : ICommandHandler<UpdateEduBlockCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetEduBlockForId _getEduBlockForId;

        public UpdateEduBlockCommandHandler(IUnitOfWork unitOfWork, IGetEduBlockForId getEduBlockForId)
        {
            _unitOfWork = unitOfWork;
            _getEduBlockForId = getEduBlockForId;
        }
        
        public async Task<Unit> Handle(UpdateEduBlockCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = await _getEduBlockForId.GetDetailAsync(request.EduBlockId);
            ExceptionHelper.CheckRule(new EduBlockDoesNotExistRule(eduBlock));

            eduBlock.UpdateEduBlockData(request.Remarks, request.Place, request.StartEduBlock, request.EndEduBlock);

            await _unitOfWork.Repository<EduBlock>().EditAsync(eduBlock);
            await _unitOfWork.CommitAsync();
            
            return Unit.Value;
        }
    }
}