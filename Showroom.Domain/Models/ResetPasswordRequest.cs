using System.ComponentModel.DataAnnotations;

namespace Showroom.Domain.Models
{
    public class ResetPasswordRequest
    {
        public int IdUser { get; set; }
        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
