using ECommerce.Domain.Repositories.Categories;

namespace ECommerce.Infrustructure.Persistance.Repositories.Categories;

public class CategoryCommandRepository(AppDbContext dbContext) : ICategoryCommandRepository
{
    public async Task AddAsync(Category category) => await dbContext.Categories.AddAsync(category);
    public void Delete(Category category) => dbContext.Categories.Remove(category);
    public void Update(Category category) => dbContext.Categories.Update(category);
    }
