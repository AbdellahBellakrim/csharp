

namespace CityInfo.Api.src.services;

public interface IMailService
{
    void send(string subject, string message);
}