namespace ECommerce.Application.Dtos.Users;

public class GetUserDtoMapping : Profile
{
    public GetUserDtoMapping()
    {
        CreateMap<User,GetUserDto>();
    }
}