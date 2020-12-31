using Autofac;
using PlainClasses.Infrastructure.Auths;

namespace PlainClasses.Infrastructure.IoC.Modules
{
    public class AuthModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHasher>()
                .As<IPasswordHasher>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<JwtHandler>()
                .As<IJwtHandler>()
                .InstancePerLifetimeScope();
        }
    }
}