using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LawInOrderApp.Infra.CrossCutting.Identity.Services;

namespace LawInOrderApp.Infra.CrossCutting.Identity.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender sender, string email, string link){
            return sender.SendEmailAsync(email, "Confirm your email",
                                          $"Please confirm your account by clicking this link: <a htre='{HtmlEncoder.Default.Encode(link)}'>Link</a>");
        }
    }
}
