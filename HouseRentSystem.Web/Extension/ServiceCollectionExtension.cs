using HouseRentSystem.Core.Contracts;
using HouseRentSystem.Core.Services;
using HouseRentSystem.Data;
using HouseRentSystem.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseRentSystem.Web.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IStatisicService, StatisticService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<HouseRentingDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepozitory, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config) 
        { 
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    
                     options.SignIn.RequireConfirmedAccount = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireDigit = false;
                     options.Password.RequiredLength = 6;
                })
                .AddEntityFrameworkStores<HouseRentingDbContext>();

            return services;
        }
    }
}
