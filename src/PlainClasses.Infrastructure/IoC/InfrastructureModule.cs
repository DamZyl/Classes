using Autofac;
using Microsoft.Extensions.Configuration;
using PlainClasses.Infrastructure.IoC.Modules;

namespace PlainClasses.Infrastructure.IoC
{
    public class InfrastructureModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public InfrastructureModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new AuthModule());
            builder.RegisterModule(new DataAccessModule(_configuration));
            builder.RegisterModule(new DomainModule());
            builder.RegisterModule(new MediatrModule());
            builder.RegisterModule(new RepositoryModule());
        }
    }
}