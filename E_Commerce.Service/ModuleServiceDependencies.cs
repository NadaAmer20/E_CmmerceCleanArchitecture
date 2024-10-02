using E_Commerce.Service.Abstracts;
using E_Commerce.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependendcies(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUserServices, ApplicationUserServices>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IImageServices, ImageServices>();
            services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            services.AddTransient<ICartServices, CartServices>();
            services.AddTransient<IAuthorizationServices, AuthorizationServices>();
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IReviewServices, ReviewServices>();

            return services;
        }
    }
}
