namespace ECommerce.Application.Features.Orders.Confirm;

public record ConfirmOrderCommand(Guid OrderId) : IRequest<Response<string>>, IValidatorRequest;
