using ECommerce.Application.Dtos.Orders;

namespace ECommerce.Application.Features.Orders.GetDetails;

public record GetOrderDetailsQuery(Guid OrderId) : IRequest<Response<GetOrderDetails>>, IValidatorRequest;
