using System.ComponentModel.DataAnnotations;

namespace SinglePageApp.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; } = default!;

        [Required]
        public string Password { get; set; } = default!;
    }
}
