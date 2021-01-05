using PlainClasses.Domain.EduBlocks;
using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.EduBlocks.Rules
{
    public class EduBlockDoesNotExistRule : IBusinessRule
    {
        private readonly EduBlock _eduBlock;

        public EduBlockDoesNotExistRule(EduBlock eduBlock)
        {
            _eduBlock = eduBlock;
        }

        public bool IsBroken() => _eduBlock == null;

        public string Message => $"Edu block with id: {_eduBlock.Id} does not exist.";
    }
}