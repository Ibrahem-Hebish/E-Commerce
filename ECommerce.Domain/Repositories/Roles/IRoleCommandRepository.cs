namespace ECommerce.Domain.Repositories.Roles;

public interface IRoleCommandRepository
{
    Task AddAsync(Role role);
    void Update(Role role);
    void Delete(Role role);
}
