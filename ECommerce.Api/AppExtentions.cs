using ECommerce.Api.Middlewares;
using Hangfire;

namespace ECommerce.Api;

public static class AppExtentions
{
    public static async Task ConfigureAsync(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var passwordHashingService = scope.ServiceProvider.GetRequiredService<IPasswordHashingService>();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await RoleSeeder.SeedAsync(dbContext);
            await UserSeeder.SeedAsync(dbContext, passwordHashingService);

        }

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddleware<GlobalExceptionHandler>();

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseHangfireDashboard("/hangfire");

        app.MapControllers();

    }
}
