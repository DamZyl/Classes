using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.EduBlocks.Commands.CreateEduBlock;
using PlainClasses.Application.EduBlocks.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.EduBlocks.Commands.AddPlatoon
{
    public class AddPlatoonCommandHandler : ICommandHandler<AddPlatoonCommand, ReturnEduBlockViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPlatoonForId _getPlatoonForId;

        public AddPlatoonCommandHandler(IUnitOfWork unitOfWork, IGetPlatoonForId getPlatoonForId)
        {
            _unitOfWork = unitOfWork;
            _getPlatoonForId = getPlatoonForId;
        }
        
        public async Task<ReturnEduBlockViewModel> Handle(AddPlatoonCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == request.EduBlockId,
                includes: i => i.Include(x => x.Platoons));
            ExceptionHelper.CheckRule(new EduBlockDoesNotExistRule(eduBlock));
            
            eduBlock.AddPlatoonToEduBlock(request.PlatoonId, _getPlatoonForId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ReturnEduBlockViewModel { Id = eduBlock.Id };
        }
    }
}