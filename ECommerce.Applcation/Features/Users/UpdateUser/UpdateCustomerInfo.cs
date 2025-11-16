namespace ECommerce.Application.Features.Users.UpdateUser;

public record UpdateCustomerInfo(Guid Id, string? Name, string? Phone) : IRequest<Response<string>>, IValidatorRequest;
