namespace ECommerce.Application.Features.Products.GetById;

public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id can not be empty")
           .NotNull().WithMessage("Id can not be null.");

    }
}
