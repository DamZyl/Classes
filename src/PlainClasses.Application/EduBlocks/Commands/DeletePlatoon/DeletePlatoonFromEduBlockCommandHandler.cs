using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.EduBlocks.DomainServices;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.EduBlocks.Commands.DeletePlatoon
{
    public class DeletePlatoonFromEduBlockCommandHandler : ICommandHandler<DeletePlatoonFromEduBlockCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPlatoonInEduBlockForId _getPlatoonInEduBlockForId;

        public DeletePlatoonFromEduBlockCommandHandler(IUnitOfWork unitOfWork, IGetPlatoonInEduBlockForId getPlatoonInEduBlockForId)
        {
            _unitOfWork = unitOfWork;
            _getPlatoonInEduBlockForId = getPlatoonInEduBlockForId;
        }
        
        public async Task<Unit> Handle(DeletePlatoonFromEduBlockCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == request.EduBlockId,
                    includes: i => i.Include(x => x.Platoons));
            ExceptionHelper.CheckRule(new EduBlockDoesNotExistRule(eduBlock));
            
            eduBlock.DeletePlatoonFromEduBlock(request.PlatoonId, _getPlatoonInEduBlockForId);

            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}