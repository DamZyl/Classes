using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlainClasses.Application.Configurations.Data;
using PlainClasses.Application.Configurations.Options;
using PlainClasses.Infrastructure.Databases.Sql;
using PlainClasses.Infrastructure.Utils;

namespace PlainClasses.Infrastructure.IoC.Modules
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public DataAccessModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var dbConfig = _configuration.GetSection(Consts.DbConfigurationSection).Get<SqlOption>();
            
            builder.Register(p => dbConfig).SingleInstance();
            
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", dbConfig.ConnectionString)
                .InstancePerLifetimeScope();


            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<PlainClassesContext>();
                    dbContextOptionsBuilder.UseSqlServer(dbConfig.ConnectionString, options => 
                        options.MigrationsAssembly("PlainClasses.Api"));
                    // dbContextOptionsBuilder
                    //     .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    return new PlainClassesContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}