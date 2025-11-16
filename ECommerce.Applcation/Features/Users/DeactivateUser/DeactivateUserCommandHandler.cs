
namespace ECommerce.Application.Features.Users.DeactivateUser;

public class DeactivateUserCommandHandler(
    IUserQueryRepository userQueryRepository,
    IUserCommandRepository userCommandRepository,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<DeactivateUserCommand, Response<string>>
{
    public async Task<Response<string>> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userQueryRepository.GetByIdAsync(request.Id);

        if (user is null)
            return NotFound<string>();

        userCommandRepository.Delete(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Deleted<string>();
    }
}
