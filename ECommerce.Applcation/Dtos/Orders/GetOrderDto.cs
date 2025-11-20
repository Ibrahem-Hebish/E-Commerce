namespace ECommerce.Application.Dtos.Orders;

public class GetOrderDto
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public GetUserDto Customer { get; set; }
}
