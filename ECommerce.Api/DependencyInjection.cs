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
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"));
        });

        services.AddScoped<GlobalExceptionHandler>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
