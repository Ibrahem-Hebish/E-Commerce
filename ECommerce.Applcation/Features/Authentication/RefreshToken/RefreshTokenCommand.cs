
namespace ECommerce.Application.Features.Authentication.RefreshToken;

public record RefreshTokenCommand(string RefreshToken) : IRequest<Response<UserTokenDto>>, IValidatorRequest;
