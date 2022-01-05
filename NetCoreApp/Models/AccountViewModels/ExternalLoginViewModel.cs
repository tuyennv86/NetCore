using System.ComponentModel.DataAnnotations;

namespace NetCoreApp.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}