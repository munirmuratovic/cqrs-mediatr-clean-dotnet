using LeaveManagement.Application.Contracts.Identity;
using LeaveManagement.Application.Models.Identity;
using LeaveManagement.Identity.DbContext;
using LeaveManagement.Identity.Models;
using LeaveManagement.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeaveManagement.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        services.AddDbContext<LeaveManagementIdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PgConnectionString"));
            options.EnableSensitiveDataLogging();
        });

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<LeaveManagementIdentityDbContext>();

        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();

        services.AddAuthenticationCore(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        return services;
    }
}
