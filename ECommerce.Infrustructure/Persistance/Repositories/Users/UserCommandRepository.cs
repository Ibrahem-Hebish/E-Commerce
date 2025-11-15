using ECommerce.Domain.Repositories.Users;

namespace ECommerce.Infrustructure.Persistance.Repositories.Users;

public class UserCommandRepository(AppDbContext dbContext) : IUserCommandRepository
{
    public async Task AddAsync(User user) => await dbContext.Users.AddAsync(user);
    public void Delete(User user) => dbContext.Users.Remove(user);
    public void Update(User user) => dbContext.Users.Update(user);
}
