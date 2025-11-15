namespace ECommerce.Domain.Repositories.Orders;

public interface IOrderQueryRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
}