using ECommerce.Application.Features.Orders.Sort;

namespace ECommerce.Infrustructure.Persistance.Repositories.Orders;

public class OrderQueryRepository(AppDbContext dbContext) : IOrderQueryRepository
{
    public async Task<List<Order>> GetAllAsync() => await dbContext.Orders
        .AsNoTracking()
        .ToListAsync();
    public async Task<Order?> GetByIdAsync(Guid id) => await dbContext.Orders.FindAsync(id);
    public async Task<List<Order>> GetOrdersByCustomerIdAsync(Guid customerId) => await dbContext.Orders
                                                                                .AsNoTracking()
                                                                                 .Where(o => o.CustomerId == customerId)
                                                                                 .ToListAsync();


    public async Task<Order?> GetOrderDetailsAsync(Guid orderId, bool asNotTracking = true)
    {
        if (asNotTracking)
        {

            return await dbContext.Orders
                                    .AsNoTracking()
                                    .Include(o => o.OrderItems)
                                    .ThenInclude(o => o.Product)
                                    .FirstOrDefaultAsync(o => o.Id == orderId);

        }
        else
        {

            return await dbContext.Orders
                         .Include(o => o.OrderItems)
                            .ThenInclude(o => o.Product)
                         .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }

    public async Task<Order?> GetWithItemsAsync(Guid Id) => await dbContext.Orders
        .AsTracking()
        .Where(o => o.Id == Id)
        .Include(o => o.OrderItems)
        .FirstOrDefaultAsync();
    public async Task<Order?> GetByIdempotencyKeyAsync(Guid idempotancyKey) => await dbContext.Orders
        .FirstOrDefaultAsync(o => o.IdempotencyKey == idempotancyKey);

    public async Task<List<Order>> Paginate(DateTime? lastCreatedAt, int? pageSize, PaginationDirection paginationDirection)
    {
        pageSize ??= 10;

        if (lastCreatedAt is null)
        {
            return await dbContext.Orders
                                   .OrderByDescending(p => p.OrderDate)
                                   .Take(pageSize.Value)
                                   .ToListAsync();
        }

        if (paginationDirection == PaginationDirection.Forward)
        {
            return await dbContext.Orders
                                   .Where(p => p.OrderDate < lastCreatedAt)
                                   .OrderByDescending(p => p.OrderDate)
                                   .Take(pageSize.Value)
                                   .ToListAsync();
        }
        else
        {
            var orders = await dbContext.Orders
                                   .Where(o => o.OrderDate > lastCreatedAt)
                                   .OrderBy(o => o.OrderDate)
                                   .Take(pageSize.Value)
                                   .ToListAsync();

            return [.. orders.OrderByDescending(o => o.OrderDate)];
        }
    }
    public async Task<List<Order>> SortByAsync(SortOrdersBy sortProductBy, SortDirection direction)
    {
        var expression = SortOrdersExpressions.SortExpressions[sortProductBy.ToString().ToLower()];

        if (direction == SortDirection.Ascending)
        {
            return await dbContext.Orders
                .AsNoTracking()
                .OrderBy(expression)
                .ToListAsync();
        }
        else
        {
            return await dbContext.Orders
                .AsNoTracking()
                .OrderByDescending(expression)
                .ToListAsync();
        }
    }

}
