namespace ECommerce.Application.Features.Users.GetUserById;

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not be empty")
           .NotNull().WithMessage("Id can not be null.");

    }
}
