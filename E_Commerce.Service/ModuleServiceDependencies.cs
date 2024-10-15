using E_Commerce.Service.Abstracts;
using E_Commerce.Service.Implementations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependendcies(this IServiceCollection services)
        {
          
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IImageServices, ImageServices>();
            services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            services.AddTransient<ICartServices, CartServices>();
            services.AddTransient<IAuthorizationServices, AuthorizationServices>();
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IReviewServices, ReviewServices>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IApplicationUserServices, ApplicationUserServices>();


            return services;
        }
    }
}
