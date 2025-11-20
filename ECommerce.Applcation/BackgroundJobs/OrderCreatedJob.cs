namespace ECommerce.Application.BackgroundJobs;

public class OrderCreatedJob(IEmailService emailService)
{
    public async Task SendOrderCreatedEmail(string email, Guid orderId)
    {
        var message = $@"
            <h1>Order Created Successfully</h1>
            <p>Dear Customer,</p>
            <p>Your order with ID {orderId} has been created successfully. We are processing your order and will notify you once it is shipped.</p>
            <p>Thank you for shopping with us!</p>
            <p>Best regards,<br/>The E-Commerce Team</p>";
        var subject = "Your Order Has Been Created";
        var emailContent = new EmailContent(email, message, subject);
        await emailService.SendEmail(emailContent);
    }
}
