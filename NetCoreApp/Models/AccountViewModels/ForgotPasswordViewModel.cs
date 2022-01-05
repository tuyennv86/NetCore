using System.ComponentModel.DataAnnotations;

namespace NetCoreApp.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}