
namespace ECommerce.Application.Features.Users.GetAllUsers;

public class GetAllCustomersQueryHandler(
    IUserQueryRepository userQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetAllCustomersQuery, Response<List<GetUserDto>>>
{
    public async Task<Response<List<GetUserDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var users = await userQueryRepository.GetAllAsync();

        if (users is null || users.Count == 0)
            return NotFound<List<GetUserDto>>();

        var dtos = mapper.Map<List<GetUserDto>>(users);

        return Success(dtos);
    }
}
