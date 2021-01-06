using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Platoons.Rules
{
    public class PlatoonDoesNotExistRule : IBusinessRule
    {
        private readonly Platoon _platoon;

        public PlatoonDoesNotExistRule(Platoon platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon with id: {_platoon.Id} does not exist.";
    }
}