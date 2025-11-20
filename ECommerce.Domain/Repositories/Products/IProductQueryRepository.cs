namespace ECommerce.Domain.Repositories.Products;

public interface IProductQueryRepository
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetByCategoryIdAsync(Guid categoryId);
    Task<List<Product>> SearchByNameAsync(string name);
    Task<List<Product>> GetByIdsAsync(List<Guid> Ids);
    Task<Product?> GetByCategoryIdAndName(Guid? categoryId, string name);
    Task<List<Product>> Paginate(DateTime? lastCreatedAt, int? pageSize, PaginationDirection paginationDirection);
    Task<List<Product>> SortByAsync(SortProductBy sortProductBy, SortDirection direction);
}
