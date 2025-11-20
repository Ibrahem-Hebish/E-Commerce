using System.Security.Claims;

namespace ECommerce.Application.Features.Users.UpdateUser;

public class UpdateCustomerInfoHandler(
    IUserQueryRepository userQueryRepository,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork)

    : ResponseHandler,
    IRequestHandler<UpdateCustomerInfo, Response<string>>
{
    public async Task<Response<string>> Handle(UpdateCustomerInfo request, CancellationToken cancellationToken)
    {
        var context = httpContextAccessor.HttpContext!;
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (request.Id != Guid.Parse(userId!))
            return UnAuthorize<string>();

        var user = await userQueryRepository.GetByIdAsync(request.Id);

        if (user is null)
            return NotFound<string>();

        user.Update(request.Name, request.Phone);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return NoContent<string>();

    }
}
