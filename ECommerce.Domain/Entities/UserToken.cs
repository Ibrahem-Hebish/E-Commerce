namespace ECommerce.Domain.Entities;

public class UserToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public DateTime AccessTokenExpireDate { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpireDate { get; set; }
    public bool IsActive { get; set; } = true;



    public void MarkAsInactive()
    {
        IsActive = false;
        RefreshTokenExpireDate = DateTime.UtcNow;
        AccessTokenExpireDate = DateTime.UtcNow;
    }

    public bool Validate()
    {
        if (!IsActive)
            return false;

        if (RefreshTokenExpireDate < DateTime.UtcNow)
        {
            MarkAsInactive();
            return false;
        }

        if (AccessTokenExpireDate > DateTime.UtcNow)
            return false;

        return true;
    }

    public void Refresh(string accessToken, DateTime accessTokenExpireDate, string refreshToken)
    {
        AccessTokenExpireDate = accessTokenExpireDate;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}