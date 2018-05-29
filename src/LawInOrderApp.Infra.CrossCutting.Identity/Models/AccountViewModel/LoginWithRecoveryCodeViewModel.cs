using System.ComponentModel.DataAnnotations;
namespace LawInOrderApp.Infra.CrossCutting.Identity.Models.AccountViewModel
{
    public class LoginWithRecoveryCodeViewModel
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recovery Code")]
        public string RecoveryCode { get; set; }
    }
}
