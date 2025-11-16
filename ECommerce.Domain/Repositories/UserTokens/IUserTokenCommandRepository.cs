namespace ECommerce.Domain.Repositories.UserTokens;

public interface IUserTokenCommandRepository
{
    Task AddAsync(UserToken userToken);
    void Update(UserToken userToken);
    void Delete(UserToken userToken);
}
