using System.Linq.Expressions;

namespace ECommerce.Application.Features.Products.SortProducts;

public static class SortProductsExpressions
{
    public static readonly Dictionary<string, Expression<Func<Product, object>>> SortExpressions = new()
    {
        { "name", p => p.Name },
        { "price", p => p.TotalPrice },
        { "createdat", p => p.CreatedAt}
    };
}

