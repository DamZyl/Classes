namespace PlainClasses.Domain.Utils.SharedKernels
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}