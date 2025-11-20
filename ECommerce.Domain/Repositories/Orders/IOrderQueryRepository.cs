namespace ECommerce.Domain.Repositories.Orders;

public interface IOrderQueryRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<Order?> GetWithItemsAsync(Guid Id);
    Task<List<Order>> GetAllAsync();
    Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<Order?> GetOrderDetailsAsync(Guid orderId, bool asNotTracking = true);
    Task<Order?> GetByIdempotencyKeyAsync(Guid idempotancyKey);
    Task<List<Order>> Paginate(DateTime? lastCreatedAt, int? pageSize, PaginationDirection paginationDirection);
    Task<List<Order>> SortByAsync(SortOrdersBy sortProductBy, SortDirection direction);
}