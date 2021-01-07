using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class PlatoonDoesNotExistRule : IBusinessRule
    {
        private readonly PlatoonInEduBlock _platoon;

        public PlatoonDoesNotExistRule(PlatoonInEduBlock platoon)
        {
            _platoon = platoon;
        }

        public bool IsBroken() => _platoon == null;

        public string Message => $"Platoon does not exist.";
    }
}