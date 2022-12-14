using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACar")));

            return services;
        }
    }
}
