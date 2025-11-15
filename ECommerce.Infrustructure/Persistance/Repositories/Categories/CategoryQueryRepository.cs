using ECommerce.Domain.Repositories.Categories;

namespace ECommerce.Infrustructure.Persistance.Repositories.Categories;

public class CategoryQueryRepository(AppDbContext dbContext) : ICategoryQueryRepository
{
    public async Task<List<Category>> GetAllAsync() => await dbContext.Categories.AsNoTracking().ToListAsync();
    public async Task<Category?> GetByIdAsync(Guid id) => await dbContext.Categories.FindAsync(id);

}
