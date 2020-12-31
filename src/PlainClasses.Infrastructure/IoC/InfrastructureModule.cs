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
            builder.RegisterModule<AuthModule>();
            builder.RegisterModule<MediatrModule>();
            builder.RegisterModule<RepositoryModule>();
        }
    }
}