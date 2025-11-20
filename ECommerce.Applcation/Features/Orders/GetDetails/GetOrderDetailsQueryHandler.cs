using ECommerce.Application.Dtos.Orders;
using ECommerce.Domain.Repositories.Orders;
using System.Security.Claims;

namespace ECommerce.Application.Features.Orders.GetDetails;

public class GetOrderDetailsQueryHandler(
    IOrderQueryRepository orderQueryRepository,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetOrderDetailsQuery, Response<GetOrderDetails>>
{
    public async Task<Response<GetOrderDetails>> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var context = httpContextAccessor.HttpContext!;
        var role = context.User.FindFirstValue(ClaimTypes.Role);
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var order = await orderQueryRepository.GetOrderDetailsAsync(request.OrderId);

        if (order is null)
            return NotFound<GetOrderDetails>();

        if (role != "Admin" && order.CustomerId != Guid.Parse(userId!))
            return UnAuthorize<GetOrderDetails>();

        var dto = mapper.Map<GetOrderDetails>(order);

        return Success(dto);
    }
}
