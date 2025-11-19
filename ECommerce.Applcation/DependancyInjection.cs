namespace ECommerce.Application;

public static class DependancyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddHttpContextAccessor();

        services.AddSingleton<ICacheGroups, CacheGroups>();

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

            opt.AddOpenBehavior(typeof(ReseatCachingPipeline<,>));
            opt.AddOpenBehavior(typeof(QueryCachingPipeline<,>));
        });

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;

    }
}
