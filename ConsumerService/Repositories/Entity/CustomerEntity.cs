using System;

namespace ConsumerService.Repositories.Entity
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {
        }

        public CustomerEntity(Guid id, CustomerEntity customer)
        {
            Id = id;
            Address = customer.Address;
            Email = customer.Email;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Gender = customer.Gender;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public long AreaCode { get; set; }
        public string Email { get; set; }
    }
}
