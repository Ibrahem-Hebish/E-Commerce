namespace ECommerce.Domain.Repositories.Users;

public interface IUserQueryRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
}