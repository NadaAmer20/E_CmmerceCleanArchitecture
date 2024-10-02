using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using E_Commerce.Core.Behaviors;
using System.Reflection;
using FluentValidation.AspNetCore;
using E_Commerce.Core.Mapping.Categories;

namespace E_Commerce.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {
            // Configuration of MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Register Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register the pipeline behavior for validation
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddAutoMapper(typeof(CategoriesProfile)); // Ensure CategoriesProfile is included


            return services;
        }
    }
}
