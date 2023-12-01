using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; init; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name is too long or short.")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name is too long or short.")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8-50 characters long.")]
        public string Password { get; set; } = string.Empty;

        public CustomerDto(string email, string password, string firstName, string lastName, Guid id)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}