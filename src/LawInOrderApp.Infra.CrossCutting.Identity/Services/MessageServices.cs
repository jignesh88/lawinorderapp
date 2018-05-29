using System.Threading.Tasks;
namespace LawInOrderApp.Infra.CrossCutting.Identity.Services
{
    public class AuthEmailMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // put in your email service here to send email
            return Task.FromResult(0);
        }
    }

    public class AuthSmsMessageSender : ISmsSender {

        public Task SendSmsAync(string number, string message)
        {
            return Task.FromResult(0);
        }
    }
}
