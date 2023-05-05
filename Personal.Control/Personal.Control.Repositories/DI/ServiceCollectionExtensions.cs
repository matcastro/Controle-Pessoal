using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Personal.Control.Repositories.Contexts;
using Personal.Control.Repositories.Repositories;
using Personal.Control.Repositories.Repositories.Interfaces;

namespace Personal.Control.Repositories.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseServer = Environment.GetEnvironmentVariable("MYSQL_DATABASE_SERVER");
            var databaseUser = Environment.GetEnvironmentVariable("MYSQL_DATABASE_USER");
            var databasePassword = Environment.GetEnvironmentVariable("MYSQL_DATABASE_PASSWORD");
            var connectionString = configuration.GetConnectionString("Control")!;
            connectionString = string.Format(connectionString, databaseServer, databaseUser, databasePassword);

            services.AddDbContextFactory<ApplicationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            services.AddSingleton<IUserRepository, UserRepository>();
        }
    }
}
