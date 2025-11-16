using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.Authentication;

public interface IAuthenticationService
{
    UserToken GenerateTokenAsync(User user);
    Task<UserToken> RefreshToken(UserToken userToken);
}
