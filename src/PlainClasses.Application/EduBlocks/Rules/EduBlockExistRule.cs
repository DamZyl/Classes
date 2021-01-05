using PlainClasses.Application.EduBlocks.Queries.GetEduBlock;
using PlainClasses.Domain.Models.Utils;

namespace PlainClasses.Application.EduBlocks.Rules
{
    public class EduBlockExistRule : IBusinessRule
    {
        private readonly EduBlockDetailViewModel _eduBlock;

        public EduBlockExistRule(EduBlockDetailViewModel eduBlock)
        {
            _eduBlock = eduBlock;
        }

        public bool IsBroken() => _eduBlock == null;

        public string Message => $"Edu block with id: {_eduBlock.Id} does not exist.";
    }
}