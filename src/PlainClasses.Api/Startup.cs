using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlainClasses.Api.Configurations.Extensions;
using PlainClasses.Api.Utils;
using PlainClasses.Api.Validations;
using PlainClasses.Application.Configurations.Validation;
using PlainClasses.Domain.Utils.SharedKernels;
using PlainClasses.Infrastructure.Databases.Sql;
using PlainClasses.Infrastructure.IoC;

namespace PlainClasses.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSqlConfiguration(Configuration, Consts.DbConfigurationSection);
            services.AddDbContext<PlainClassesContext>();
            
            services.AddJwtConfiguration(Configuration, Consts.JwtConfigurationSection);
            services.AddControllers();
            services.AddSwagger();
            services.AddProblemDetails(x =>
            {
                x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
                x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            });
            
            var builder = new ContainerBuilder();
            
            builder.Populate(services);
            builder.RegisterModule(new InfrastructureModule(Configuration));
            
            var container = builder.Build();
            return new AutofacServiceProvider(container); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseProblemDetails();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(Consts.ApiSwaggerUrl, Consts.ApiName);
            });
        }
    }
}
