using System.Data;

namespace PlainClasses.Application.Configurations.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}