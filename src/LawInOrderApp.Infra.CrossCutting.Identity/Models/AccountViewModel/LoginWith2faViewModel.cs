using System.ComponentModel.DataAnnotations;
namespace LawInOrderApp.Infra.CrossCutting.Identity.Models.AccountViewModel
{
    public class LoginWith2faViewModel
    {
        [Required]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} character long", MinimumLength = 7)]
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator Code")]
        public string TwoFactorCode { get; set; }

        [Display(Name = "Remember this Machine")]
        public bool RememberMachine { get; set; }

        public bool RememberMe { get; set; }
    }
}
