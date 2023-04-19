using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Shared.Models.Data
{
    public class UserLoginRecord
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
