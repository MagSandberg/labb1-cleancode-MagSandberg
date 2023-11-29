using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class CustomerModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50), Required]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress, Required]
        public string Email { get; set; }

        [MinLength(8), MaxLength(50), Required]
        public string Password { get; set; }

        public CustomerModel(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}