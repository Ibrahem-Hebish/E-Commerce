using ECommerce.Application.Dtos.OrderItems;

namespace ECommerce.Application.Dtos.Orders;

public class GetOrderDetails
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public GetUserDto Customer { get; set; }
    public List<GetOrderItemDto> OrderItems { get; set; } = [];
}
