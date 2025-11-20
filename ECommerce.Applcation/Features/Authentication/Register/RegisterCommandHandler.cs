namespace ECommerce.Application.Features.Authentication.Register;

public class RegisterCommandHandler(
    IUserQueryRepository userQueryRepository,
    IUserCommandRepository userCommandRepository,
    IPasswordHashingService passwordHashingService,
    IUnitOfWork unitOfWork,
    IRoleQueryRepository roleQueryRepository,
    IMapper mapper
    ) : ResponseHandler,
    IRequestHandler<RegisterCommand, Response<string>>
{
    public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userQueryRepository.GetByEmailAsync(request.Email);

        if (existingUser is not null)
            return BadRequest<string>("Email is already in use.");

        var hashedPassword = passwordHashingService.HashPasswordBCrypt(request.Password);

        var user = mapper.Map<User>(request);

        user.SetPassword(hashedPassword);

        var role = await roleQueryRepository.GetByNameAsync("Customer");

        if (role is null)
        {
            Log.Error("Role 'Customer' not found in the database.");

            return InternalServerError<string>("An error occurred while processing your request.");
        }

        user.AssignRole(role);

        await userCommandRepository.AddAsync(user);

        user.NewCustomerRegistered();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Success("User registered successfully.");

    }
}
