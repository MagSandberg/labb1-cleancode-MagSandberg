using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class CustomerModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerId { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        [MinLength(8), MaxLength(50), Required]
        public string Password { get; set; }

        public ICollection<OrderModel> Orders { get; set; }


        public CustomerModel()
        {
            
        }

        public CustomerModel(Guid id, string firstName, string lastName, string email, string password, ICollection<OrderModel> orders)
        {
            CustomerId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Orders = orders;
        }
    }
}