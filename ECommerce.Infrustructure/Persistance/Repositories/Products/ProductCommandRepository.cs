using ECommerce.Domain.Repositories.Products;

namespace ECommerce.Infrustructure.Persistance.Repositories.Products;

public class ProductCommandRepository(AppDbContext dbContext) : IProductCommandRepository
{
    public async Task AddAsync(Product product) => await dbContext.Products.AddAsync(product);
    public void Delete(Product product) => dbContext.Products.Remove(product);
    public void Update(Product product) => dbContext.Products.Update(product);

}
