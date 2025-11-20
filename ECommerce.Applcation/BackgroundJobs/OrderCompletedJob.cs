namespace ECommerce.Application.BackgroundJobs;

public class OrderCompletedJob(IEmailService emailService)
{
    public async Task SendOrderCompletedEmail(string email, Guid orderId)
    {
        var message = $@"
            <h1>Order Completed</h1>
            <p>Dear Customer,</p>
            <p>Your order with ID {orderId} has been completed successfully. Thank you for shopping with us!</p>
            <p>We look forward to serving you again.</p>
            <p>Best regards,<br/>The E-Commerce Team</p>";

        var subject = "Your Order Has Been Completed";

        var emailContent = new EmailContent(email, message, subject);

        await emailService.SendEmail(emailContent);
    }
}