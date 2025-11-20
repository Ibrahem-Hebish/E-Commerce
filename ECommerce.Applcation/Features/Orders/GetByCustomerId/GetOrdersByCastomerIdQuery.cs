using ECommerce.Application.Dtos.Orders;

namespace ECommerce.Application.Features.Orders.GetByCustomerId;

public record GetOrdersByCastomerIdQuery(Guid CustomerId) : IRequest<Response<List<GetOrderDto>>>, IValidatorRequest;
