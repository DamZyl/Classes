using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlainClasses.Domain.Platoons;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Domain.EduBlocks.Rules
{
    public class PlatoonsIdsCountEqualPlatoonsCount : IBusinessRule
    {
        private readonly IEnumerable<Guid> _platoonsIds;
        private readonly IEnumerable<Platoon> _platoons;

        public PlatoonsIdsCountEqualPlatoonsCount(IEnumerable<Guid> platoonsIds, IEnumerable<Platoon> platoons)
        {
            _platoonsIds = platoonsIds;
            _platoons = platoons;
        }

        public bool IsBroken() => _platoonsIds.Count() != _platoons.Count();

        public string Message => GetMessage();

        private IEnumerable<Guid> DifferentIds()
        {
            var result = _platoonsIds.Where(x => _platoons.All(p => x != p.Id)).ToList();

            return result;
        }

        private string GetMessage()
        {
            var items = DifferentIds().ToList();

            if (items.Count() <= 1) 
                return $"Platoon with id: {items.First()} does not exist.";
            
            var text = new StringBuilder();
            text.Append("Platoons with id: ");

            foreach (var item in items)
            {
                text.AppendFormat(@"{0} ", item);
            }

            text.Append("do not exist.");

            return text.ToString();
        }
    }
}