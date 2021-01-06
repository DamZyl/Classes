using Autofac;
using PlainClasses.Application.EduBlocks.DomainServices;
using PlainClasses.Application.Persons.DomainServices;
using PlainClasses.Application.Platoons.DomainServices;
using PlainClasses.Domain.EduBlocks.DomainServices;
using PlainClasses.Domain.Persons.DomainServices;
using PlainClasses.Domain.Platoons.DomainServices;
using PlainClasses.Domain.Utils.SharedKernels.DomainServices;

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
            
            builder.RegisterType<GetEduBlockSubjectForId>()
                .As<IGetEduBlockSubjectForId>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetPlatoonsForIds>()
                .As<IGetPlatoonsForIds>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetPersonForId>()
                .As<IGetPersonForId>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<GetEduBlockForId>()
                .As<IGetEduBlockForId>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<ChangePlatoonForPerson>()
                .As<IChangePlatoonForPerson>()
                .InstancePerLifetimeScope();
        }
    }
}