using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// Model representing an order
/// </summary>
namespace DamianMuchaDom2.Models
{
    public class Order
    {
        [Required]
        public int BookId { get; set; }
        [Required(ErrorMessage="Email is required!")]
        [EmailAddress(ErrorMessage ="Incorrect email address!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Phone number is required!")]
        [Phone(ErrorMessage ="Incorrect phone number!")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Order date is required!")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage ="First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last name is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="City is required!")]
        public string City { get; set; }
        [Required(ErrorMessage ="Address is required!")]
        public string Address { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
