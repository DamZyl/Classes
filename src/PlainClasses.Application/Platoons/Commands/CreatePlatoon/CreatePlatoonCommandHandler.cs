using System.Threading;
using System.Threading.Tasks;
using PlainClasses.Application.Configurations.Dispatchers;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Repositories;

namespace PlainClasses.Application.Platoons.Commands.CreatePlatoon
{
    public class CreatePlatoonCommandHandler : ICommandHandler<CreatePlatoonCommand, ReturnPlatoonViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlatoonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ReturnPlatoonViewModel> Handle(CreatePlatoonCommand request, CancellationToken cancellationToken)
        {
            var platoon = Platoon.CreatePlatoon(request.Name, request.Acronym, request.Commander);

            await _unitOfWork.Repository<Platoon>().AddAsync(platoon);
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ReturnPlatoonViewModel { Id = platoon.Id };
        }
    }
}