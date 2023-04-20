using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Models.Data
{
    public sealed record UserRegisterRecord
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required, StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;
        
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
