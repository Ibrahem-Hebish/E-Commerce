using ECommerce.Application.Dtos.Orders;
using ECommerce.Domain.Repositories.Orders;

namespace ECommerce.Application.Features.Orders.Paginate;

public class PaginateOrdersQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<PaginateOrdersQuery, Response<List<GetOrderDto>>>
{
    public async Task<Response<List<GetOrderDto>>> Handle(PaginateOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderQueryRepository.Paginate(request.LastCreatedAt,
            request.PageSize, request.PaginationDirection);

        if (orders is null || orders.Count == 0)
            return NotFound<List<GetOrderDto>>("No orders found.");

        var ordersDto = mapper.Map<List<GetOrderDto>>(orders);

        return Success(ordersDto);
    }
}