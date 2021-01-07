using System.Collections.Generic;
using System.Linq;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class PlatoonIsInEduBlockRule : IBusinessRule
    {
        private readonly IEnumerable<PlatoonInEduBlock> _platoons;
        private readonly Platoon _platoon;

        public PlatoonIsInEduBlockRule(IEnumerable<PlatoonInEduBlock> platoons, Platoon platoon)
        {
            _platoons = platoons;
            _platoon = platoon;
        } 
        
        public bool IsBroken() => _platoons.Any(x => x.PlatoonId == _platoon.Id);

        public string Message => $"Platoon with id: {_platoon.Id} already is in edu block.";
    }
}