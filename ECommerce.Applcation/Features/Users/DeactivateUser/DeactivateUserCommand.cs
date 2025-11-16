
namespace ECommerce.Application.Features.Users.DeactivateUser;

public record DeactivateUserCommand(Guid Id) : IRequest<Response<string>>, IValidatorRequest;
