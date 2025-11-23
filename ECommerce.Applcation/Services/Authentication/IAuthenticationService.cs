namespace ECommerce.Application.Services.Authentication;

public interface IAuthenticationService
{
    UserToken GenerateTokenAsync(User user);
}
