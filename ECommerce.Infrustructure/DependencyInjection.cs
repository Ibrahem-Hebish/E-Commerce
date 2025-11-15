namespace ECommerce.Infrustructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrustructure(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("json.json")
            .AddUserSecrets(typeof(DependencyInjection).Assembly)
            .Build();

        services.Configure<EmailSettings>(config.GetSection("Email"));
        services.AddTransient<IEmailService, EmailService>();

        services.AddSerilog();

        Log.Logger = new LoggerConfiguration()
                         .ReadFrom.Configuration(config)
                         .CreateLogger();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();

        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();

        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
        services.AddScoped<IProductQueryRepository, ProductQueryRepository>();

        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

        services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
        services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

        services.AddTransient<IPasswordHashingService, PasswordHashingService>();

        return services;
    }
}
