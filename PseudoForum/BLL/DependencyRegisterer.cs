using BLL.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DependencyRegisterer
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(ICRUDService<>), typeof(CRUDService<>));
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<Hasher>();
            DAL.DependencyRegisterer.Register(serviceCollection, configuration);
        }
    }
}
