namespace ECommerce.Application.Dtos.UserTokens;

public class UserTokenMapping : Profile
{
    public UserTokenMapping()
    {
        CreateMap<UserToken,UserTokenDto>();
    }
}