using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaQuotAuth.Repository;

namespace TaQuotAuth.Utils
{
    public static class StartupExtension
    {

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<TaQuotAuthContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));

    }
}
