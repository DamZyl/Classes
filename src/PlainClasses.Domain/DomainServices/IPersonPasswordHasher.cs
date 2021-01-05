namespace PlainClasses.Domain.DomainServices
{
    public interface IPersonPasswordHasher
    {
        string Hash(string password);
    }
}