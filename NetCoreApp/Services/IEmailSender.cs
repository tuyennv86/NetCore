using System.Threading.Tasks;

namespace NetCoreApp.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}