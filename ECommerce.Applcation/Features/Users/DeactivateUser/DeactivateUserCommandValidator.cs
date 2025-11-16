namespace ECommerce.Application.Features.Users.DeactivateUser;

public class DeactivateUserCommandValidator : AbstractValidator<DeactivateUserCommand>
{
    public DeactivateUserCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not be empty")
           .NotNull().WithMessage("Id can not be null.");

    }
}
