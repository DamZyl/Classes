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

namespace PlainClasses.Application.EduBlocks.Commands.DeleteFunction
{
    public class DeleteFunctionCommandHandler : ICommandHandler<DeleteFunctionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPersonFunctionForId _getPersonFunctionForId;

        public DeleteFunctionCommandHandler(IUnitOfWork unitOfWork, IGetPersonFunctionForId getPersonFunctionForId)
        {
            _unitOfWork = unitOfWork;
            _getPersonFunctionForId = getPersonFunctionForId;
        }
        
        public async Task<Unit> Handle(DeleteFunctionCommand request, CancellationToken cancellationToken)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>()
                .FindByWithIncludesAsync(x => x.Id == request.EduBlockId,
                    includes: i => i.Include(x => x.PersonFunctions));
            ExceptionHelper.CheckRule(new EduBlockDoesNotExistRule(eduBlock));
            
            eduBlock.DeleteFunctionPerson(request.FunctionId, _getPersonFunctionForId);

            await _unitOfWork.CommitAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}