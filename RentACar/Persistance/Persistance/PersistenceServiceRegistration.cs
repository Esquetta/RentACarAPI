﻿using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IFuelRepository, FuelRepository>();
            services.AddScoped<ICarColorRepository, CarColorRepository>();
            services.AddScoped<IGearBoxRepository, GearBoxRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IRentDetailRepository, RentDetailRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IOperationClaimRepository, OperationClaimRepostiory>();
            services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
            services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACar")));

            return services;
        }
    }
}
