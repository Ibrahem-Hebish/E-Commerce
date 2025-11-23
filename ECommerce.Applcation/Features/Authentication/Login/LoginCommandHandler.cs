namespace ECommerce.Application.Features.Authentication.Login;

public class LoginCommandHandler(
    IAuthenticationService authenticationService,
    IUserQueryRepository userQueryRepository,
    IPasswordHashingService passwordHashingService,
    IUserTokenCommandRepository userTokenCommandRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<LoginCommand, Response<UserTokenDto>>
{
    public async Task<Response<UserTokenDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var user = await userQueryRepository.GetByEmailAsync(request.Email);

            if (user is null)
                return BadRequest<UserTokenDto>("Invalid Credintial.");

            var validPassword = passwordHashingService.VerifyPasswordBCrypt(request.Password, user.PasswordHash);

            if (!validPassword)
                return BadRequest<UserTokenDto>("Invalid Credintial.");

            UserToken token = authenticationService.GenerateTokenAsync(user);

            await userTokenCommandRepository.AddAsync(token);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            await unitOfWork.CommitTransactionAsync();

            var tokenDto = mapper.Map<UserTokenDto>(token);

            return Success(tokenDto);

        }
        catch (Exception ex)
        {
            Log.Error("Error while login for user with Email {email}.Full exception : {ex}", request.Email, ex);

            await unitOfWork.RollbackTransactionAsync();

            return InternalServerError<UserTokenDto>();
        }

    }
}
