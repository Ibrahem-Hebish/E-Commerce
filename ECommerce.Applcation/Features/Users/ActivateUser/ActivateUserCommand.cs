namespace ECommerce.Application.Features.Users.ActivateUser;

public record ActivateUserCommand(Guid Id) : IRequest<Response<string>>, IValidatorRequest;
