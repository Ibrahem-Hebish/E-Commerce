
namespace ECommerce.Application.Features.Authentication.RefreshToken;

public class RefreshTokenCommandHandler(
    IUserTokenQueryRepository userTokenQueryRepository,
    IAuthenticationService authenticationService,
    IUserQueryRepository userQueryRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<RefreshTokenCommand, Response<UserTokenDto>>
{
    public async Task<Response<UserTokenDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var userToken = await userTokenQueryRepository.GetByRefrehToken(request.RefreshToken);

        if (userToken is null)
            return BadRequest<UserTokenDto>();

        var user = await userQueryRepository.GetByIdAsync(userToken.UserId);

        if (user is null)
            return NotFound<UserTokenDto>();

        var valid = userToken.Validate();

        if (!valid)
            return BadRequest<UserTokenDto>();

        var newToken = authenticationService.GenerateTokenAsync(user);

        userToken.Refresh(newToken.AccessToken, newToken.AccessTokenExpireDate, newToken.RefreshToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var tokenDto = mapper.Map<UserTokenDto>(userToken);

        return Success(tokenDto);
    }
}
