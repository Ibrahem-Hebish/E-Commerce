namespace ECommerce.Application.Features.Users.UpdateUser;

public class UpdateCustomerInfoHandler(
    IUserQueryRepository userQueryRepository,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<UpdateCustomerInfo, Response<string>>
{
    public async Task<Response<string>> Handle(UpdateCustomerInfo request, CancellationToken cancellationToken)
    {
        var user = await userQueryRepository.GetByIdAsync(request.Id);

        if (user is null)
            return NotFound<string>();

        user.Update(request.Name, request.Phone);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return NoContent<string>();

    }
}
