using System.Threading.Tasks;

namespace TimimInnovation.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string subject, string body, string from = null, string attachmentFilePath = null);
    }
}
