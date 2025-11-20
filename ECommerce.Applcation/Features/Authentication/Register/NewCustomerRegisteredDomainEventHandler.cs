using ECommerce.Domain.Events;
using Hangfire;

namespace ECommerce.Application.Features.Authentication.Register;

public class NewCustomerRegisteredDomainEventHandler : INotificationHandler<CustomerRegisteredEvent>
{
    public Task Handle(CustomerRegisteredEvent notification, CancellationToken cancellationToken)
    {
        BackgroundJob.Enqueue<WelcomeEmailJob>(job =>
           job.SendWelcomeEmail(notification.Email, notification.Customer.Name)
        );

        return Task.CompletedTask;

    }
}
