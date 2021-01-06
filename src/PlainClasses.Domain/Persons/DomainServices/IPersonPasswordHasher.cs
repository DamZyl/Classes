namespace PlainClasses.Domain.Persons.DomainServices
{
    public interface IPersonPasswordHasher
    {
        string Hash(string password);
        bool Check(string hash, string password);
    }
}