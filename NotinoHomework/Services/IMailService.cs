using NotinoHomework.Models.Email;

namespace NotinoHomework.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
