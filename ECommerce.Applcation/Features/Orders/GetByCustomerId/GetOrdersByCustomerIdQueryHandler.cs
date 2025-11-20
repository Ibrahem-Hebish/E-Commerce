using ECommerce.Application.Dtos.Orders;
using ECommerce.Domain.Repositories.Orders;

namespace ECommerce.Application.Features.Orders.GetByCustomerId;

public class GetOrdersByCustomerIdQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetOrdersByCastomerIdQuery, Response<List<GetOrderDto>>>
{
    public async Task<Response<List<GetOrderDto>>> Handle(GetOrdersByCastomerIdQuery request, CancellationToken cancellationToken)
    {
        var customerOrders = await orderQueryRepository.GetOrdersByCustomerIdAsync(request.CustomerId);

        if(customerOrders is null || customerOrders.Count == 0)
            return NotFound<List<GetOrderDto>>("No orders found for the specified customer.");

        var dtos = mapper.Map<List<GetOrderDto>>(customerOrders);

        return Success(dtos);
    }
}


