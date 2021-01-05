using PlainClasses.Domain.Utils.SharedKernels;

namespace PlainClasses.Application.Utils
{
    public static class ExceptionHelper
    {
        public static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}