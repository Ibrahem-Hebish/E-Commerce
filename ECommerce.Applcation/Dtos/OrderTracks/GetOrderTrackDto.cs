namespace ECommerce.Application.Dtos.OrderTracks;

public class GetOrderTrackDto
{
    public Guid OrderId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
