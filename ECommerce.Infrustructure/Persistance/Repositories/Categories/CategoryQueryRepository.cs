namespace ECommerce.Infrustructure.Persistance.Repositories.Categories;

public class CategoryQueryRepository(AppDbContext dbContext) : ICategoryQueryRepository
{
    public async Task<List<Category>> GetAllAsync() => await dbContext.Categories.AsNoTracking().ToListAsync();
    public async Task<Category?> GetByIdAsync(Guid id) => await dbContext.Categories.FindAsync(id);
    public async Task<bool> ExistsByNameAsync(string Name) => await dbContext.Categories
        .AnyAsync(x => x.Name.ToLower() == Name.ToLower());

    public async Task<bool> HasProducts(Guid id) => await dbContext.Categories
        .Where(x => x.Id == id)
        .AnyAsync(x => x.Products.Any());

}
