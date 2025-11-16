namespace ECommerce.Application.Dtos.UserTokens;

public class UserTokenDto
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpireDate { get; set; }
}
