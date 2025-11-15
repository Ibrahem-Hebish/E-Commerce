using ECommerce.Domain.Repositories.Orders;

namespace ECommerce.Infrustructure.Persistance.Repositories.Orders;

public class OrderQueryRepository(AppDbContext dbContext) : IOrderQueryRepository
{
    public async Task<List<Order>> GetAllAsync() => await dbContext.Orders.AsNoTracking().ToListAsync();
    public async Task<Order?> GetByIdAsync(Guid id) => await dbContext.Orders.FindAsync(id);
    public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId) => await dbContext.Orders
                                                                                .AsNoTracking()
                                                                                 .Where(o => o.CustomerId == customerId)
                                                                                 .ToListAsync();
}
