using Bibliocine.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Bibliocine.API.Configurations.Auth;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(opt => 
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        
        return services;
    }
}