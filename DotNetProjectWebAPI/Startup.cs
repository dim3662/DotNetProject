using DotNetProject.DotNetProjectBLL.Contracts;
using DotNetProject.DotNetProjectBLL.Implementations;
using DotNetProject.DotNetProjectDataAccess.Context;
using DotNetProject.DotNetProjectDataAccess.Contracts;
using DotNetProject.DotNetProjectDataAccess.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetProjectWebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));

            // BLL
            services.Add(new ServiceDescriptor(typeof(ISecretCreateService), typeof(SecretCreateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISecretGetService), typeof(SecretGetService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISecretUpdateService), typeof(SecretUpdateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IMessageGetService), typeof(MessageGetService),
                ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(ISecretDataAccess), typeof(SecretDataAccess),
                ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IMessageDataAccess), typeof(MessageDataAccess),
                ServiceLifetime.Transient));

            // DB Contexts
            services.AddDbContext<SecretDirectoryContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("SecretDirectory")));

            // BLL
            services.Add(new ServiceDescriptor(typeof(IPersonCreateService), typeof(PersonCreateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonGetService), typeof(PersonGetService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IPersonUpdateService), typeof(PersonUpdateService),
                ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(ISecretGetService), typeof(SecretGetService),
                ServiceLifetime.Scoped));

            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IPersonDataAccess), typeof(PersonDataAccess),
                ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(ISecretDataAccess), typeof(SecretDataAccess),
                ServiceLifetime.Transient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}