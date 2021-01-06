using PlainClasses.Application.Platoons.Queries.GetPlatoon;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Platoons.Rules
{
    public class PlatoonExistsRule : IBusinessRule
    {
        private readonly PlatoonDetailViewModel _platoon;

        public PlatoonExistsRule(PlatoonDetailViewModel platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon with id: {_platoon.Id} does not exist.";
    }
}