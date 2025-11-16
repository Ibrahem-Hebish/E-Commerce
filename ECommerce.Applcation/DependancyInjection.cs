
using ECommerce.Application.BackgroundJobs;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddHttpContextAccessor();

        var config = new ConfigurationBuilder()
           .AddJsonFile("applicationjson.json")
           .Build();

        services.AddSerilog();

        Log.Logger = new LoggerConfiguration()
                         .ReadFrom.Configuration(config)
                         .CreateLogger();

        services.AddMemoryCache();

        services.AddValidatorsFromAssemblyContaining<IEmailService>();

        services.AddTransient<WelcomeEmailJob>();

        services.AddAutoMapper(cfg => { }, typeof(DependancyInjection).Assembly);

        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(typeof(DependancyInjection).Assembly);
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;

    }
}
