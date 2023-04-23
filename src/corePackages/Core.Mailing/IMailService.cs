namespace Core.Mailing;

public interface IMailService
{
    Task SendMail(Mail mail);
}