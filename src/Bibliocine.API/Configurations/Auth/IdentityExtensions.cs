using System.Text;
using Bibliocine.Business.Entities;
using Bibliocine.Infra.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Bibliocine.API.Configurations.Auth;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<ApplicationDbContext>(opt => 
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

        services.AddIdentity<Usuario, IdentityRole<Guid>>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddErrorDescriber<IdentityMessagesPortuguese>()
            .AddDefaultTokenProviders();

        // JWT
        var configIdentitySection = configuration.GetSection("IdentityConfig");
        services.Configure<IdentityConfig>(configIdentitySection);

        var configIdentity = configIdentitySection.Get<IdentityConfig>();
        var key = Encoding.ASCII.GetBytes(configIdentity!.Secret);

        services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = configIdentity.ValidoEm,
                ValidIssuer = configIdentity.Emissor
            };
        });
            
        return services;
    }
}