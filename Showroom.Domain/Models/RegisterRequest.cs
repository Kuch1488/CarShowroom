using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Domain.Models
{
    public class RegisterRequest
    {
        public string UserName { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
