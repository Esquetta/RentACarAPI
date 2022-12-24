using Application.Featues.Brands.Rules;
using Application.Featues.CarColors.Rules;
using Application.Featues.CarModels.Rules;
using Application.Featues.Cars.Rules;
using Application.Featues.Fuels.Rules;
using Application.Featues.GearBoxses.Rules;
using Application.Featues.OperationClaims.Rules;
using Application.Featues.Photos.Rules;
using Application.Featues.UserOperationClaims.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<BrandBusinessRules>();
            services.AddScoped<FuelBusinessRules>();
            services.AddScoped<CarColorBusinessRules>();
            services.AddScoped<GearBoxBusinessRules>();
            services.AddScoped<CarModelBusinessRules>();
            services.AddScoped<CarBusinessRules>();
            services.AddScoped<PhotoBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            return services;
        }
    }
}
