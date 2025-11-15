namespace ECommerce.Infrustructure.Persistance.Repositories.Orders;

public class OrderCommandRepository(AppDbContext dbContext) : IOrderCommandRepository
{
    public async Task AddAsync(Order order) => await dbContext.Orders.AddAsync(order);
    public void Delete(Order order) => dbContext.Orders.Remove(order);
    public void Update(Order order) => dbContext.Orders.Update(order);
}
