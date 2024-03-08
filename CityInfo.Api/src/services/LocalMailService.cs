
namespace CityInfo.Api.src.services;

public class LocalMailService : IMailService
{
    private readonly string? _mailTo;
    private readonly string? _mailFrom;
    public LocalMailService(IConfiguration configuration)
    {
        _mailTo = configuration["MailSettings:mailToAddress"];
        _mailFrom = configuration["MailSettings:mailFromAddress"];
    }

    public void send(string subject, string message)
    {
        Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}
