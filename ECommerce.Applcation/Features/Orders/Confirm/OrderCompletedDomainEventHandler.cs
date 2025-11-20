using ECommerce.Domain.Events;
using Hangfire;

namespace ECommerce.Application.Features.Orders.Confirm;

public class OrderCompletedDomainEventHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        BackgroundJob.Enqueue<OrderCompletedJob>(job =>
           job.SendOrderCompletedEmail(notification.Email, notification.OrderId)
        );
        return Task.CompletedTask;
    }
}