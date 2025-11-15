namespace ECommerce.Infrustructure.Persistance.Repositories.Products;

public class ProductQueryRepository(AppDbContext dbContext) : IProductQueryRepository
{
    public async Task<List<Product>> GetAllAsync() => await dbContext.Products.AsNoTracking().ToListAsync();
    public async Task<List<Product>> GetByCategoryIdAsync(Guid categoryId) => await dbContext.Products
        .AsNoTracking()
        .Where(p => p.CategoryId == categoryId)
        .ToListAsync();
    public async Task<Product?> GetByIdAsync(Guid id) => await dbContext.Products.FindAsync(id);

}