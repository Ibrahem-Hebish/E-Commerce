namespace ECommerce.Application.Features.Products.SearchByName;

public class SearchProductsByNameQueryValidator : AbstractValidator<SearchProductsByNameQuery>
{
    public SearchProductsByNameQueryValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty.")
            .NotNull()
            .WithMessage("Name can not be null.");
    }
}
