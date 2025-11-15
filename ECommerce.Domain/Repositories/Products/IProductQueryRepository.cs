namespace ECommerce.Domain.Repositories.Products;

public interface IProductQueryRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetByCategoryIdAsync(Guid categoryId);

}
