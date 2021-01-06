using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Platoons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.Platoons.Commands.DeletePlatoon
{
    public class DeletePlatoonCommandHandler : ICommandHandler<DeletePlatoonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPlatoonForId _getPlatoonForId;

        public DeletePlatoonCommandHandler(IUnitOfWork unitOfWork, IGetPlatoonForId getPlatoonForId)
        {
            _unitOfWork = unitOfWork;
            _getPlatoonForId = getPlatoonForId;
        }
        
        public async Task<Unit> Handle(DeletePlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _getPlatoonForId.GetAsync(request.PlatoonId);
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));

            await _unitOfWork.Repository<Platoon>().DeleteAsync(platoon);
            await _unitOfWork.CommitAsync();
            
            return Unit.Value;
        }
    }
}