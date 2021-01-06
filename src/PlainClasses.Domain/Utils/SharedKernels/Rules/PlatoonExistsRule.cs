using PlainClasses.Domain.Platoons;

namespace PlainClasses.Domain.Utils.SharedKernels.Rules
{
    public class PlatoonExistsRule : IBusinessRule
    {
        private readonly Platoon _platoon;

        public PlatoonExistsRule(Platoon platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon with id: {_platoon.Id} does not exist.";
    }
}