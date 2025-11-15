namespace ECommerce.Infrustructure.Persistance.Repositories.Roles;

public class RoleQueryRepository(AppDbContext dbContext) : IRoleQueryRepository
{
    public async Task<List<Role>> GetAllAsync() => await dbContext.Roles.ToListAsync();
    public async Task<Role?> GetByIdAsync(Guid roleId) => await dbContext.Roles.FindAsync(roleId);
    public async Task<Role?> GetByNameAsync(string roleName) => await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);

}
