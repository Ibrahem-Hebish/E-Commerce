namespace ECommerce.Application.Features.Categories.GetById;

public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
{
    public GetCategoryByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id can nt be emprt.")
            .NotNull().WithMessage("Id can not be null.");
    }
}