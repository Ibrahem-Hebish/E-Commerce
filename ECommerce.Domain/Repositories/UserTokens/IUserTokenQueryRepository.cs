namespace ECommerce.Domain.Repositories.UserTokens;

public interface IUserTokenQueryRepository
{
    Task<List<UserToken>> GetAllAsync();
    Task<UserToken?> GetByIdAsync(Guid id);
    Task<UserToken?> GetByRefrehToken(string refrshToken);
}