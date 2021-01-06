using System.Collections.Generic;
using PlainClasses.Application.Platoons.Queries.GetPlatoons;

namespace PlainClasses.Application.Platoons.Queries.GetPlatoon
{
    public class PlatoonDetailViewModel : PlatoonViewModel
    {
        public List<PersonForPlatoonViewModel> Persons { get; set; }
    }
}