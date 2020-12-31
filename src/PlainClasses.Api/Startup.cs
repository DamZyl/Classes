using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlainClasses.Api.Extensions;
using PlainClasses.Api.Utils;
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
            services.AddSql(Configuration, Consts.DbConfigurationSection);
            services.AddJwtConfiguration(Configuration, Consts.JwtConfigurationSection);
            services.AddControllers();
            services.AddSwagger();
            
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
