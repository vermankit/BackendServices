using System;
using System.ComponentModel.DataAnnotations;

namespace ConsumerService.Modals
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(Guid id, Customer customer)
        {
            Id = id;
            Address = customer.Address;
            Email = customer.Email;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Gender = customer.Gender;
        }

        public Guid Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Gender { get; set; }

        [Required] public string Address { get; set; }

        public long AreaCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}