namespace ECommerce.Application.Features.Users.ActivateUser;

public class ActivateUserCommandValidator : AbstractValidator<ActivateUserCommand>
{
    public ActivateUserCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not be empty")
           .NotNull().WithMessage("Id can not be null.");

    }
}
