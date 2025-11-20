namespace ECommerce.Application.BackgroundJobs;

public class OrderCanceledJob(IEmailService emailService)
{
    public async Task SendOrderCanceledEmail(string email, Guid orderId)
    {
        var message = $@"
            <h1>Order Canceled</h1>
            <p>Dear Customer,</p>
            <p>Your order with ID {orderId} has been canceled. If you have any questions, please contact our support team.</p>
            <p>We hope to serve you again in the future!</p>
            <p>Best regards,<br/>The E-Commerce Team</p>";

        var subject = "Your Order Has Been Canceled";

        var emailContent = new EmailContent(email, message, subject);

        await emailService.SendEmail(emailContent);
    }
}
