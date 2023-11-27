using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class CustomerDTO
    {
        public Guid Id { get; init; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8-50 characters long.")]
        public string Password { get; set; } = string.Empty;
    }
}