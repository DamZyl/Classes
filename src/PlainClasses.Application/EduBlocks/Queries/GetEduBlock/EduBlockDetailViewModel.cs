using System.Collections.Generic;
using PlainClasses.Application.EduBlocks.Queries.GetEduBlocks;

namespace PlainClasses.Application.EduBlocks.Queries.GetEduBlock
{
    public class EduBlockDetailViewModel : EduBlockViewModel
    {
        public string Remarks { get; set; }
        public List<PersonFunctionViewModel> PersonFunctions { get; set; }
        public List<PlatoonInEduBlockViewModel> PlatoonsInEduBlock { get; set; }
    }
}