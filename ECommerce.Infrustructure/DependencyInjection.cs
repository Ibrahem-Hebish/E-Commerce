using ECommerce.Domain.Repositories.OrderTracks;
using ECommerce.Infrustructure.Persistance.Repositories.OrderTracks;
using Hangfire;

namespace ECommerce.Infrustructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrustructure(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("json.json")
            .AddUserSecrets(typeof(DependencyInjection).Assembly)
            .Build();

        var connectionString = config.GetSection("ConnectionString").Value;

        services.AddHangfire(config =>
        {
            config.UseSqlServerStorage(connectionString);
        });

        services.AddHangfireServer();

        services.Configure<EmailSettings>(config.GetSection("Email"));
        services.AddTransient<IEmailService, EmailService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();

        services.AddScoped<IUserTokenCommandRepository, UserTokenCommandRepository>();
        services.AddScoped<IUserTokenQueryRepository, UserTokenQueryRepository>();

        services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
        services.AddScoped<IRoleQueryRepository, RoleQueryRepository>();

        services.AddScoped<IProductCommandRepository, ProductCommandRepository>();
        services.AddScoped<IProductQueryRepository, ProductQueryRepository>();

        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();

        services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
        services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();

        services.AddScoped<IOrderTrackCommandRepository, OrderTrackCommandRepository>();
        services.AddScoped<IOrderTrackQueryRepository, OrderTrackQueryRepository>();

        services.AddTransient<IPasswordHashingService, PasswordHashingService>();



        services.Configure<JwtOptions>(config.GetSection("jwt"));

        var jwt = config.GetSection("jwt").Get<JwtOptions>();

        var signingKey = config["jwtsigningkey"];

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.SaveToken = true;

                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt!.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwt!.Audience,
                        ClockSkew = TimeSpan.Zero,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                               Encoding.UTF8.GetBytes(signingKey!)),
                    };
                }
                );

        services.AddAuthorization();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
