using Contracts;
using Contracts.IRepositories;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;
using Service.Contracts;
using System.Reflection;

namespace AcQua_TaQuot.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureUtils(this IServiceCollection services, IConfiguration configuration)
        {
            var JWTSection = configuration.GetSection("JWT");
            services.AddSingleton<IJWTService>(s => new JWTService(JWTSection.GetValue<string>("key"),
                                                                   JWTSection.GetValue<string>("meAsIssuer"),
                                                                   JWTSection.GetValue<string>("audience")));
        }
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

    }
}
