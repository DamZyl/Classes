using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.Platoons.Rules
{
    public class PlatoonExistRule : IBusinessRule
    {
        private readonly Platoon _platoon;

        public PlatoonExistRule(Platoon platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon with id: {_platoon.Id} does not exist.";
    }
}