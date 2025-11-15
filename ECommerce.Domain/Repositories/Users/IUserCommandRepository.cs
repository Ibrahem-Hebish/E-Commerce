namespace ECommerce.Domain.Repositories.Users;

public interface IUserCommandRepository
{
    Task AddAsync(User user);
    void Update(User user);
    void Delete(User user);
}
