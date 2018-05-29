using System.ComponentModel.DataAnnotations;
namespace LawInOrderApp.Infra.CrossCutting.Identity.Models.AccountViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
