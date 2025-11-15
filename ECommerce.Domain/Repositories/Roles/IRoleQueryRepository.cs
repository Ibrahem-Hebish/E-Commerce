namespace ECommerce.Domain.Repositories.Roles;

public interface IRoleQueryRepository
{
    Task<Role?> GetByIdAsync(Guid roleId);
    Task<Role?> GetByNameAsync(string roleName);
    Task<List<Role>> GetAllAsync();
}