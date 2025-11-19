namespace ECommerce.Domain.Repositories.Categories;

public interface ICategoryQueryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<List<Category>> GetAllAsync();
    Task<bool> ExistsByNameAsync(string Name);
    Task<bool> HasProducts(Guid Id);
}