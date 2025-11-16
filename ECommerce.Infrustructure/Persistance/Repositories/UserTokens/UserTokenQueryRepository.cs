namespace ECommerce.Infrustructure.Persistance.Repositories.UserTokens;

public class UserTokenQueryRepository(AppDbContext dbContext) : IUserTokenQueryRepository
{
    public async Task<List<UserToken>> GetAllAsync() => await dbContext.UserTokens.AsNoTracking().ToListAsync();
    public async Task<UserToken?> GetByIdAsync(Guid id) => await dbContext.UserTokens.FindAsync(id);
    public async Task<UserToken?> GetByRefrehToken(string refrshToken) => await dbContext.UserTokens
        .Where(ut => ut.RefreshToken == refrshToken)
        .FirstOrDefaultAsync();

}
