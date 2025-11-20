using ECommerce.Domain.Repositories.Orders;

namespace ECommerce.Application.Features.Orders.Sort;

public class SortOrdersQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper) 
    
    :ResponseHandler,
    IRequestHandler<SortOrdersQuery, Response<List<Order>>>
{
    public async Task<Response<List<Order>>> Handle(SortOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderQueryRepository.SortByAsync(request.SortBy, request.Direction);

        if (orders is null || orders.Count == 0)
            return NotFound<List<Order>>("No orders found.");

        var ordersDto = mapper.Map<List<Order>>(orders);

        return Success(ordersDto);
    }
}