namespace ECommerce.Domain.Repositories.Categories;

public interface ICategoryQueryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<List<Category>> GetAllAsync();
}