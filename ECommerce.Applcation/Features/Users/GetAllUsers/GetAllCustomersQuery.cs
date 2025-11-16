using ECommerce.Application.Dtos.Users;

namespace ECommerce.Application.Features.Users.GetAllUsers;

public record GetAllCustomersQuery : IRequest<Response<List<GetUserDto>>>;
