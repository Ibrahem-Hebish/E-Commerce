namespace ECommerce.Application.Features.Users.GetUserById;

public record GetUserByIdQuery(Guid Id) : IRequest<Response<GetUserDto>>;
