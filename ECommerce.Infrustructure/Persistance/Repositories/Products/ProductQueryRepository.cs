using ECommerce.Application.Features.Products.SortProducts;

namespace ECommerce.Infrustructure.Persistance.Repositories.Products;

public class ProductQueryRepository(AppDbContext dbContext) : IProductQueryRepository
{
    public async Task<List<Product>> GetAllAsync() => await dbContext.Products
        .AsNoTracking()
        .ToListAsync();

    public async Task<Product?> GetByCategoryIdAndName(Guid? categoryId, string name)
    {
        if (categoryId == null)
            return null;

        return await dbContext.Products
             .Where(p => (p.CategoryId == categoryId && p.Name.ToLower() == name.ToLower()))
             .FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetByCategoryIdAsync(Guid categoryId) => await dbContext.Products
        .AsNoTracking()
        .Where(p => p.CategoryId == categoryId)
        .ToListAsync();
    public async Task<Product?> GetByIdAsync(Guid id) => await dbContext.Products.FindAsync(id);

    public async Task<List<Product>> SearchByNameAsync(string name) => await dbContext.Products
        .AsNoTracking()
        .Where(p => p.Name.Contains(name))
        .ToListAsync();


    public async Task<List<Product>> Paginate(DateTime? lastCreatedAt, int? pageSize, PaginationDirection paginationDirection)
    {
        pageSize ??= 10;

        if (lastCreatedAt is null)
        {
            return await dbContext.Products
                                   .OrderByDescending(p => p.CreatedAt)
                                   .Take(pageSize.Value)
                                   .ToListAsync();
        }

        if (paginationDirection == PaginationDirection.Forward)
        {
            return await dbContext.Products
                                   .Where(p => p.CreatedAt < lastCreatedAt)
                                   .OrderByDescending(p => p.CreatedAt)
                                   .Take(pageSize.Value)
                                   .ToListAsync();
        }
        else
        {
            var products = await dbContext.Products
                                   .Where(p => p.CreatedAt > lastCreatedAt)
                                   .OrderBy(p => p.CreatedAt)
                                   .Take(pageSize.Value)
                                   .ToListAsync();

            return [.. products.OrderByDescending(p => p.CreatedAt)];
        }
    }


    public async Task<List<Product>> SortByAsync(SortProductBy sortProductBy, SortDirection direction)
    {
        var expression = SortProductsExpressions.SortExpressions[sortProductBy.ToString().ToLower()];

        if (direction == SortDirection.Ascending)
        {
            return await dbContext.Products
                .AsNoTracking()
                .OrderBy(expression)
                .ToListAsync();
        }
        else
        {
            return await dbContext.Products
                .AsNoTracking()
                .OrderByDescending(expression)
                .ToListAsync();
        }
    }

    public async Task<List<Product>> GetByIdsAsync(List<Guid> Ids) => await dbContext.Products
        .AsTracking()
        .Where(p => Ids.Contains(p.Id))
        .ToListAsync();

}