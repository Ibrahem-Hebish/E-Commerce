namespace ECommerce.Application.Features.Orders.Cancel;

public class CancelOrderCommandHandler(
    IOrderQueryRepository orderQueryRepository,
    IOrderTrackCommandRepository orderTrackCommandRepository,
    IHttpContextAccessor httpContextAccessor,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<CancelOrderCommand, Response<string>>
{
    public async Task<Response<string>> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            var context = httpContextAccessor.HttpContext!;
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = context.User.FindFirstValue(ClaimTypes.Role);

            var order = await orderQueryRepository.GetOrderDetailsAsync(request.OrderId, asNotTracking: false);

            if (order is null)
                return NotFound<string>("Order not found.");

            if (role != "Admin" && order.CustomerId != Guid.Parse(userId!))
                return UnAuthorize<string>("You are not authorized to cancel this order.");

            if (order.Status == OrderStatus.Canceled)
                return BadRequest<string>("Order is already canceled.");

            order.Cancel();

            var orderTrack = new OrderTrack(OrderStatus.Canceled, order.Id);

            await orderTrackCommandRepository.AddAsync(orderTrack);

            var products = order.OrderItems
                .Where(oi => oi.ProductId is not null)
                .Select(oi => oi.Product)
                .ToList();

            if (products.Count != order.OrderItems.Count)
                return BadRequest<string>("One or more products associated with the order are invalid.");

            foreach (var product in products)
            {
                var orderItem = order.OrderItems.First(oi => oi.ProductId == product!.Id);

                product!.AddStock(orderItem.Quantity);
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            await unitOfWork.CommitTransactionAsync();

            return Success("Order canceled successfully.");

        }
        catch (Exception ex)
        {
            Log.Error("Error while canceling order with id {id}.Full exception {ex}", request.OrderId, ex);

            await unitOfWork.RollbackTransactionAsync();

            return InternalServerError<string>($"An error occurred while canceling the order: {ex.Message}");
        }
    }
}