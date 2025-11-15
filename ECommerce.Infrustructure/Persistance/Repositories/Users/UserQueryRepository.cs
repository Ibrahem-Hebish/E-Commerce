namespace ECommerce.Infrustructure.Persistance.Repositories.Users;

public class UserQueryRepository(AppDbContext dbContext) : IUserQueryRepository
{
    public async Task<User?> GetByIdAsync(Guid id) => await dbContext.Users.FindAsync(id);
    public async Task<User?> GetByEmailAsync(string email) => await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    public async Task<List<User>> GetAllAsync() => await dbContext.Users.AsNoTracking().ToListAsync();

}
