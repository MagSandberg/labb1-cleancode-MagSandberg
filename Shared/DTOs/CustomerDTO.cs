using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name is too long or short.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name is too long or short.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8-50 characters long.")]
        public string Password { get; set; }

        public ICollection<OrderDto> Orders { get; set; }


        public CustomerDto(Guid id, string firstName, string lastName, string email, string password, ICollection<OrderDto> orders)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Orders = orders;
        }
    }
}