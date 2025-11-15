using ECommerce.Application.Services.PasswordHashing;

namespace ECommerce.Infrustructure.Persistance.Seeders;
public static class UserSeeder
{
    public static async Task SeedAsync(AppDbContext dbContext, IPasswordHashingService passwordHashing)
    {
        if (dbContext.Users.Any())
            return;

        var adminRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");

        if (adminRole == null)
            throw new InvalidOperationException("Admin Role is missing in db.");

        var hashedPassword = passwordHashing.HashPasswordBCrypt("Hema123#");

        User admin = new()
        {
            Name = "Ibrahem Hebish",
            Email = "ibrahemhebish@gmail.com",
            PhoneNumber = "01224157271",
            PasswordHash = hashedPassword,
            Role = adminRole
        };

        await dbContext.Users.AddAsync(admin);

        await dbContext.SaveChangesAsync();
    }
}
