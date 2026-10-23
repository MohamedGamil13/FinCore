using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance.Extensions
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));


            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.Password.RequireDigit = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();


            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

//services
//    .AddIdentity<ApplicationUser, IdentityRole>(options =>
//    {
//        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
//        options.Password.RequireDigit = true;

//    })
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();

//services.AddScoped<IUnitOfWork, UnitOfWork>();
//services.AddScoped<IAuthRepo, AuthRepo>();
//services.AddScoped<IUserMangementRepo, UserMangementRepo>();
//services.AddScoped<IDataSeed, DataSeeding>();