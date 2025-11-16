namespace ECommerce.Application.Features.Authentication.Register;

public class RegisterUserMapping : Profile
{
    public RegisterUserMapping()
    {
        CreateMap<RegisterCommand, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
    }
}
