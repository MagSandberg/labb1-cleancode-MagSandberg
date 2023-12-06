using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class CustomerModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; init; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [MinLength(8), MaxLength(50), Required]
        public string Password { get; set; }


        public CustomerModel(string firstName, string lastName, string email, string password)
        {
            CustomerId = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}