namespace ECommerce.Application.Features.Authentication.Login;

public record LoginCommand(string Email, string Password) : IRequest<Response<UserTokenDto>>, IValidatorRequest
{ }
