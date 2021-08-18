using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSBRackets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Web.Interfaces;
using Web.Services;

namespace Web.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration congif)
        {
            services.AddScoped<Logic>();
            services.AddScoped<Mapper>();
            services.AddScoped<Repo>();
            services.AddScoped<BSDbContext>();
            services.AddScoped<ITokenService, TokenService>();
            // add connection string eventually
            return services;
        }
        
    }
}
