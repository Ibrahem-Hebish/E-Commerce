namespace ECommerce.Infrustructure.Services.Authentication;

public class AuthenticationService(
    IConfiguration configuration,
    IOptions<JwtOptions> options)

    : IAuthenticationService
{
    public UserToken GenerateTokenAsync(User user)
    {
        string accessToken;

        try
        {
            accessToken = CreateAccessToken(user);
        }
        catch
        {
            throw new InvalidOperationException("Signing key is missing from configuration.");
        }

        UserToken userToken = new()
        {
            AccessToken = accessToken,
            RefreshToken = Guid.NewGuid().ToString(),
            AccessTokenExpireDate = DateTime.UtcNow.AddMinutes(options.Value.AccessTokenLifeTime),
            RefreshTokenExpireDate = DateTime.UtcNow.AddMinutes(options.Value.RefreshTokenLifeTime),
            UserId = user.Id
        };

        return userToken;
    }

    public Task<UserToken> RefreshToken(UserToken userToken)
    {
        throw new NotImplementedException();
    }

    private string CreateAccessToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var signingkey = configuration["jwtsigningkey"];

        if (string.IsNullOrWhiteSpace(signingkey))
            throw new InvalidOperationException("Signing key is missing from configuration.");

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Issuer = options.Value.Issuer,

            Audience = options.Value.Audience,

            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(
                        signingkey!)),
                SecurityAlgorithms.HmacSha256),

            Subject = GetClaims(user),

            Expires = DateTime.UtcNow.AddMinutes(options.Value.AccessTokenLifeTime)

        };

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        var accessToken = tokenHandler.WriteToken(securityToken);

        return accessToken;
    }

    private static ClaimsIdentity GetClaims(User user)
    {
        List<Claim> userClaims = [];

        userClaims.Add(new(ClaimTypes.NameIdentifier, user.Id.ToString()));
        userClaims.Add(new(ClaimTypes.Role, user.Role.Name));

        var claimsIdentity = new ClaimsIdentity(userClaims);

        return claimsIdentity;
    }

}
