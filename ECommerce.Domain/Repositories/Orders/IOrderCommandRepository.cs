namespace ECommerce.Domain.Repositories.Orders;

public interface IOrderCommandRepository
{
    Task AddAsync(Order order);
    void Update(Order order);
    void Delete(Order order);
}
