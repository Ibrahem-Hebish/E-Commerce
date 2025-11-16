using ECommerce.Application.Dtos.Users;

namespace ECommerce.Application.Features.Users.GetUserById;

public class GetUserByIdQueryHandler(
    IUserQueryRepository userQueryRepository,
    IMapper mapper)

    : ResponseHandler,
    IRequestHandler<GetUserByIdQuery, Response<GetUserDto>>
{
    public async Task<Response<GetUserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userQueryRepository.GetByIdAsync(request.Id);

        if (user is null)
            return NotFound<GetUserDto>();

        var dto = mapper.Map<GetUserDto>(user);

        return Success(dto);
    }
}
