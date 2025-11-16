namespace ECommerce.Infrustructure.Services.Authentication;

public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double AccessTokenLifeTime { get; set; }
    public double RefreshTokenLifeTime { get; set; }
}
