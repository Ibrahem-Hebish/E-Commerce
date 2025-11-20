using System.Linq.Expressions;

namespace ECommerce.Application.Features.Orders.Sort;

public static class SortOrdersExpressions
{
    public static readonly Dictionary<string, Expression<Func<Order, object>>> SortExpressions = new()
    {
        { "orderdate", o => o.OrderDate },
        { "totalamount", o => o.TotalAmount },
        { "status", o => o.Status}
    };
}
