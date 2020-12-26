namespace PlainClasses.Domain.Models.Utils
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}