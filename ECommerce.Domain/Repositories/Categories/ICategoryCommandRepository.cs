namespace ECommerce.Domain.Repositories.Categories;

public interface ICategoryCommandRepository
{
    Task AddAsync(Category category);
    void Update(Category category);
    void Delete(Category category);
}
