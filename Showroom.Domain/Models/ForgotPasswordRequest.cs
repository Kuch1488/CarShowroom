using System.ComponentModel.DataAnnotations;

namespace Showroom.Domain.Models
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
    }
}
