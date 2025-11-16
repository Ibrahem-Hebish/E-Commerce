namespace ECommerce.Application.Features.Authentication.Register;

public record RegisterCommand : IRequest<Response<string>>, IValidatorRequest
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string ConfirmPassword { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
}
