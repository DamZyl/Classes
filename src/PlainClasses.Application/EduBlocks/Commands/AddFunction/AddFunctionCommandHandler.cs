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

namespace PlainClasses.Application.EduBlocks.Commands.AddFunction
{
    public class AddFunctionCommandHandler : ICommandHandler<AddFunctionCommand, ReturnEduBlockViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPersonForId _getPersonForId;

        public AddFunctionCommandHandler(IUnitOfWork unitOfWork, IGetPersonForId getPersonForId)
        {
            _unitOfWork = unitOfWork;
            _getPersonForId = getPersonForId;
        }
        
        public async Task<ReturnEduBlockViewModel> Handle(AddFunctionCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == request.EduBlockId,
                    includes: i => i.Include(x => x.PersonFunctions));
            ExceptionHelper.CheckRule(new EduBlockDoesNotExistRule(eduBlock));
            
            eduBlock.AddFunctionForPerson(request.PersonId, request.Function, _getPersonForId);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new ReturnEduBlockViewModel { Id = eduBlock.Id };
        }
    }
}