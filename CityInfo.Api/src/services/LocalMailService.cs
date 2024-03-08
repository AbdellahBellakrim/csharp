
namespace CityInfo.Api.src.services;

public class LocalMailService : IMailService
{
    private string _mailTo = "admin@company.com";
    private string _mailFrom = "noreplay@mycompany.com";

    public void send(string subject, string message)
    {
        Console.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Message: {message}");
    }
}
