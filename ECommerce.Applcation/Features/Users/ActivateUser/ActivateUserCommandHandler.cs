namespace ECommerce.Application.Features.Users.ActivateUser;

public class ActivateUserCommandHandler(
    IUserQueryRepository userQueryRepository,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<ActivateUserCommand, Response<string>>
{
    public async Task<Response<string>> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userQueryRepository.GetByIdAngIgnoreQueryFilterAsync(request.Id);

        if (user is null)
            return NotFound<string>();

        var success = user.Activate();

        if (!success)
            return BadRequest<string>();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Success("User is activated successfully.");
    }
}
