namespace ECommerce.Application.BackgroundJobs;

public class WelcomeEmailJob(IEmailService emailService)
{

    public async Task SendWelcomeEmail(string email, string customerName)
    {
        var message = $@"
            <h1>Welcome to E-Commerce Platform</h1>
            <p>Dear {customerName},</p>
            <p>Thank you for registering with our e-commerce platform! We're excited to have you on board.</p>
            <p>Happy shopping!</p>
            <p>Best regards,<br/>The E-Commerce Team</p>";

        var subject = "Welcome to E-Commerce Platform";

        var emailContent = new EmailContent(email, message, subject);

        await emailService.SendEmail(emailContent);
    }
}
