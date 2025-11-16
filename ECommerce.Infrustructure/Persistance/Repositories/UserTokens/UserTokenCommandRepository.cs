namespace ECommerce.Infrustructure.Persistance.Repositories.UserTokens;

public class UserTokenCommandRepository(AppDbContext dbContext) : IUserTokenCommandRepository
{
    public async Task AddAsync(UserToken userToken) => await dbContext.UserTokens.AddAsync(userToken);
    public void Delete(UserToken userToken) => dbContext.UserTokens.Remove(userToken);
    public void Update(UserToken userToken) => dbContext.UserTokens.Update(userToken);

}
