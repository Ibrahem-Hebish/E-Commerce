using ECommerce.Domain.Repositories.Roles;

namespace ECommerce.Infrustructure.Persistance.Repositories.Roles;

public class RoleCommandRepository(AppDbContext dbContext) : IRoleCommandRepository
{
    public async Task AddAsync(Role role) => await dbContext.Roles.AddAsync(role);
    public void Delete(Role role) => dbContext.Roles.Remove(role);
    public void Update(Role role) => dbContext.Roles.Update(role);
}
