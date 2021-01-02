using Autofac;
using PlainClasses.Application.Persons.DomainServices;
using PlainClasses.Domain.DomainServices;

namespace PlainClasses.Infrastructure.IoC.Modules
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonPasswordHasher>()
                .As<IPersonPasswordHasher>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetMilitaryRankForId>()
                .As<IGetMilitaryRankForId>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetPlatoonForId>()
                .As<IGetPlatoonForId>()
                .InstancePerLifetimeScope();
        }
    }
}