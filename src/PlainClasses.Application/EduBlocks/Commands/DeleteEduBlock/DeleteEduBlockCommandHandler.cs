using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.EduBlocks.Commands.DeleteEduBlock
{
    public class DeleteEduBlockCommandHandler : ICommandHandler<DeleteEduBlockCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetEduBlockForId _getEduBlockForId;

        public DeleteEduBlockCommandHandler(IUnitOfWork unitOfWork, IGetEduBlockForId getEduBlockForId)
        {
            _unitOfWork = unitOfWork;
            _getEduBlockForId = getEduBlockForId;
        }
        
        public async Task<Unit> Handle(DeleteEduBlockCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = await _getEduBlockForId.GetAsync(request.EduBlockId);
            ExceptionHelper.CheckRule(new EduBlockDoesNotExistRule(eduBlock));
            
            await _unitOfWork.Repository<EduBlock>().DeleteAsync(eduBlock);
            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}