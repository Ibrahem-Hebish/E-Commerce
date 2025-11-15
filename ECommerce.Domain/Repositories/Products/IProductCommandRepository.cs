namespace ECommerce.Domain.Repositories.Products;

public interface IProductCommandRepository
{
    Task AddAsync(Product product);
    void Update(Product product);
    void Delete(Product product);
}
