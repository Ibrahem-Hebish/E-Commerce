using ECommerce.Application.Dtos.Orders;
using ECommerce.Domain.Repositories.Orders;

namespace ECommerce.Application.Features.Orders.GetAll;

public class GetAllOrdersQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper)
    
    : ResponseHandler
    ,IRequestHandler<GetAllOrdersQuery, Response<List<GetOrderDto>>>
{
    
    public async Task<Response<List<GetOrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await orderQueryRepository.GetAllAsync();

        if (orders is null || orders.Count == 0)
            return NotFound<List<GetOrderDto>>("No orders found.");

        var ordersDto = mapper.Map<List<GetOrderDto>>(orders);

        return Success(ordersDto);
    }
}
