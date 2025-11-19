namespace ECommerce.Application.Features.Products.GetByCategory;

public class GetProductsByCategoryIdQueryValidator : AbstractValidator<GetProductsByCategoryIdQuery>
{
    public GetProductsByCategoryIdQueryValidator()
    {
        RuleFor(x => x.Id)
          .NotEmpty().WithMessage("Id can not be empty")
          .NotNull().WithMessage("Id can not be null.");
    }
}