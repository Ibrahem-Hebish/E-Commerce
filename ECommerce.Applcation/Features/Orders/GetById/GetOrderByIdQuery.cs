using ECommerce.Application.Dtos.Orders;

namespace ECommerce.Application.Features.Orders.GetById;

public record GetOrderByIdQuery(Guid Id) : IRequest<Response<GetOrderDto>>, IValidatorRequest;
