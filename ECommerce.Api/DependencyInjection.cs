using ECommerce.Api.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
    {


        services.AddControllers();

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt
            .UseLazyLoadingProxies()
            .UseSqlServer(configuration.GetConnectionString("ConnectionString"),
             sqlOptions => sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    ));
        });

        services.AddScoped<GlobalExceptionHandler>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
