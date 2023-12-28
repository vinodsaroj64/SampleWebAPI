using SmapleWebAPI.Repository;
using SmapleWebAPI.Services;
using System.Runtime.CompilerServices;

namespace SmapleWebAPI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddProductServices(this IServiceCollection serviceCollection,IConfiguration configuration)
        {

            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<IProductService, ProductService>();
        }
    }
}
