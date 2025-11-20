using ECommerce.Domain.Events;
using Hangfire;

namespace ECommerce.Application.Features.Orders.Cancel;

public class OrderCancelledDomainEventHandler : INotificationHandler<OrderCanceledEvent>
{
    public Task Handle(OrderCanceledEvent notification, CancellationToken cancellationToken)
    {
        BackgroundJob.Enqueue<OrderCanceledJob>(job =>
           job.SendOrderCanceledEmail(notification.Email, notification.OrderId)
        );
        return Task.CompletedTask;
    }
}
