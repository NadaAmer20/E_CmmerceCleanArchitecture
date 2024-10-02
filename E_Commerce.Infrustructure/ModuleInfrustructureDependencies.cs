using Microsoft.Extensions.DependencyInjection;
using E_Commerce.Infrustructure.InfrustructureBases;
using E_Commerce.Infrustructure.Abstracts;
using E_Commerce.Infrustructure.Repositories;

namespace E_Commerce.Infrastructure
{
    public static class ModuleInfrastructureDependencies 
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();

            return services;
        }
    }
}
