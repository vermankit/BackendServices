using ConsumerService.Modals;
using ConsumerService.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumerService.Services
{
    public class CustomerService : ICustomerService
    {
        public static List<Customer> Customers { get; set; }

        static CustomerService()
        {
            Customers = new List<Customer>();
        }

        public Customer Add(Customer Customer)
        {
            var alreadyExist = GetCustomersByEmail(Customer.Email);

            if (alreadyExist != null)
            {
                return alreadyExist;
            }

            Customer.Id = Customer.Id != default ? Customer.Id : Guid.NewGuid();
            Customers.Add(Customer);

            return Customer;
        }

        public List<Customer> Get()
        {
            return Customers;
        }

        public Customer Get(Guid id)
        {
            return Customers.FirstOrDefault(p => p.Id == id);
        }

        public Customer GetCustomersByEmail(string email)
        {
            return Customers.FirstOrDefault(p => p.Email == email);
        }

        public Customer Update(Guid id, Customer Customer)
        {
            Customers.Remove(Customer);
            var updatedCustomer = new Customer(id, Customer);
            Customers.Add(updatedCustomer);
            return updatedCustomer;
        }
    }
}
