using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Application.Platoons.Rules;
using PlainClasses.Application.Utils;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Repositories;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

namespace PlainClasses.Application.Platoons.Commands.UpdatePlatoon
{
    public class UpdatePlatoonCommandHandler : ICommandHandler<UpdatePlatoonCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetPlatoonForId _getPlatoonForId;

        public UpdatePlatoonCommandHandler(IUnitOfWork unitOfWork, IGetPlatoonForId getPlatoonForId)
        {
            _unitOfWork = unitOfWork;
            _getPlatoonForId = getPlatoonForId;
        }
        
        public async Task<Unit> Handle(UpdatePlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = await _getPlatoonForId.GetDetailAsync(request.PlatoonId);
            ExceptionHelper.CheckRule(new PlatoonDoesNotExistRule(platoon));

            platoon.UpdatePlatoonData(request.Commander);

            await _unitOfWork.Repository<Platoon>().EditAsync(platoon);
            await _unitOfWork.CommitAsync();
            
            return Unit.Value;
        }
    }
}