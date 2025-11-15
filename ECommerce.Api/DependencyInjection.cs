using ECommerce.Infrustructure.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                .AddInterceptors(new SoftDeleteInterceptor());
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
