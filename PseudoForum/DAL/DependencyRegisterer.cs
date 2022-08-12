using Core;
using DAL.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyRegisterer
    {
        public static void Register(IServiceCollection collection, IConfiguration configuration)
        {
            collection.AddDbContext<DbContext, ForumDbContext>(oBuilder =>
            {
                oBuilder.UseSqlServer(configuration.GetConnectionString("ForumDb"));
            });
            collection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            collection.AddScoped<IRepository<Topic>, TopicRepository>();
        }
    }
}
