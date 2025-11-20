using ECommerce.Domain.Events;
using Hangfire;

namespace ECommerce.Application.Features.Orders.Create;

public class NewOrderPlacedDomainEventHandler : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        BackgroundJob.Enqueue<OrderCreatedJob>(job =>
           job.SendOrderCreatedEmail(notification.Email, notification.OrderId)
        );
        return Task.CompletedTask;
    }
}
