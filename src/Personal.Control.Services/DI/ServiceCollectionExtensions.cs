using Microsoft.Extensions.DependencyInjection;
using Personal.Control.Services.Services;
using Personal.Control.Services.Services.Interfaces;

namespace Personal.Control.Services.DI
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds to program all services from the services layer
        /// </summary>
        /// <param name="services">Services to receive the dependency injections</param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
