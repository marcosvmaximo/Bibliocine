using Bibliocine.API.Configurations.Auth;
using Bibliocine.Domain.Entities;
using Bibliocine.Domain.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Interfaces;
using Bibliocine.ExternalServices.GoogleBooks.Rest;
using Bibliocine.ExternalServices.GoogleBooks.Services;
using Bibliocine.ExternalServices.IMDB;
using Bibliocine.ExternalServices.IMDB.Configurations;
using Bibliocine.ExternalServices.IMDB.Services;
using Bibliocine.Infra.Repositories;

namespace Bibliocine.API.Configurations;

public static class ServicesExtensions
{
    public static IServiceCollection AddServicesExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentityConfiguration(configuration);

        // App Settings
        services.Configure<TMDBSettings>(configuration.GetSection("ExternalServices:TMDB"));
        
        // IOC
        services.AddTransient<IObraService<Filme>, FilmeService>();
        services.AddTransient<IObraService<Livro>, LivroService>();
        services.AddTransient<ITMDBFilmeExternalService, TMDBFilmeExternalService>();
        services.AddTransient<IGoogleBooksExternalServices, GoogleBooksExternalServices>();
        
        services.AddTransient<IObraRepository, ObraRepository>();
        
        return services;
    }
}