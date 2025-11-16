
namespace ECommerce.Application.Features.Authentication.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(v => v.RefreshToken)
            .NotEmpty().WithMessage("Token can not be empty.")
            .NotNull().WithMessage("Token can not be null.");
    }
}