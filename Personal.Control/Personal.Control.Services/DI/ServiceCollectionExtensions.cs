using Microsoft.Extensions.DependencyInjection;
using Personal.Control.Services.Services;
using Personal.Control.Services.Services.Interfaces;

namespace Personal.Control.Services.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
        }
    }
}
