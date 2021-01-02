using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Domain.Models.Rules
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