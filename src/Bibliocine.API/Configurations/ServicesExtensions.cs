using Bibliocine.API.Configurations.Auth;
using Bibliocine.Business;
using Bibliocine.Core.Application;
using Bibliocine.Business.Entities;
using Bibliocine.Business.Services;
using Bibliocine.Business.Services.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Rest;
using Bibliocine.ExternalServices.GoogleBooks.Services;
using Bibliocine.ExternalServices.IMDB;
using Bibliocine.ExternalServices.IMDB.Configurations;
using Bibliocine.ExternalServices.IMDB.Services;
using Bibliocine.Infra.Context;
using Bibliocine.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliocine.API.Configurations;

public static class ServicesExtensions
{
    public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<DataContext>(opt => 
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        // Identity
        services.AddIdentityExtensions(configuration);

        // IOC Configurations
        services.Configure<TMDBSettings>(configuration.GetSection("ExternalServices:TMDB"));
        
        // IOC
        services.AddTransient<IObraService<Filme>, FilmeService>();
        services.AddTransient<IObraService<Livro>, LivroService>();
        services.AddTransient<IObraService<Obra>, ObraService>();
        services.AddTransient<ITMDBFilmeExternalService, TMDBFilmeExternalService>();
        services.AddTransient<IGoogleBooksExternalServices, GoogleBooksExternalServices>();

        services.AddTransient<IFavoritoService, FavoritoService>();
        services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        
        services.AddScoped<DataContext>();
        services.AddScoped<INotifyHandler, NotifyHandler>();

        // CORS
        // Liberado a todos
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });
        return services;
    }
}