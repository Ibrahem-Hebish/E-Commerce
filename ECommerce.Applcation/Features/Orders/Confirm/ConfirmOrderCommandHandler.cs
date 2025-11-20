using ECommerce.Domain.Enums;
using ECommerce.Domain.Repositories.Orders;
using ECommerce.Domain.Repositories.OrderTracks;

namespace ECommerce.Application.Features.Orders.Confirm;

public class ConfirmOrderCommandHandler(
    IOrderQueryRepository orderQueryRepository,
    IOrderTrackCommandRepository orderTrackCommandRepository,
    IUnitOfWork unitOfWork)
    : ResponseHandler,
    IRequestHandler<ConfirmOrderCommand, Response<string>>
{
    public async Task<Response<string>> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderQueryRepository.GetByIdAsync(request.OrderId);

        if (order is null)
            return NotFound<string>("Order not found.");

        order.Confirm();

        var orderTrack = new OrderTrack(OrderStatus.Completed, order.Id);

        await orderTrackCommandRepository.AddAsync(orderTrack);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Success("Order confirmed successfully.");
    }
}