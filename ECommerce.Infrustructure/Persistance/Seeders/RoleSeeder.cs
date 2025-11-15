namespace ECommerce.Infrustructure.Persistance.Seeders;

public static class RoleSeeder
{
    public static async Task SeedAsync(AppDbContext dbContext)
    {
        if (dbContext.Roles.Any())
            return;

        var roles = new List<Role>()
        {
            new()
            {
                Name = "Admin"
            },
            new()
            {
                Name = "Customer"
            }
        };

        await dbContext.Roles.AddRangeAsync(roles);

        await dbContext.SaveChangesAsync();
    }
}
