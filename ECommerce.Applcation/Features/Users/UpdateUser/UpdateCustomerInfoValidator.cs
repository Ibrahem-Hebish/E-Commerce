namespace ECommerce.Application.Features.Users.UpdateUser;

public class UpdateCustomerInfoValidator : AbstractValidator<UpdateCustomerInfo>
{
    public UpdateCustomerInfoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id can not be empty")
            .NotNull().WithMessage("Id can not be null.");

        RuleFor(x => x)
            .Must(v => !string.IsNullOrWhiteSpace(v.Name) ||
                       !string.IsNullOrWhiteSpace(v.Phone))
            .WithMessage("Either Name or Phone must be provided.");

        RuleFor(x => x.Name)
            .MaximumLength(50)
            .When(x => !string.IsNullOrWhiteSpace(x.Name))
            .WithMessage("Name can not exceed 50 chars.");


        RuleFor(x => x.Phone)
            .Matches(@"^[0-9]{1,14}$")
            .When(x => !string.IsNullOrWhiteSpace(x.Phone))
            .WithMessage("Phone must contain only digits and be 1 to 14 digits long.");
    }
}