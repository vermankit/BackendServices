using ConsumerService.Repositories.Entity;
using ConsumerService.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsumerService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        public static List<CustomerEntity> Customers { get; set; }


        static CustomerRepository()
        {
            Customers = new List<CustomerEntity>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Anu",
                    LastName = "Vig",
                    Email = "anu.vig@test.com",
                    AreaCode = 101,
                    Address = "114,Saturn Colony",
                    Gender = "F"
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Prateek",
                    LastName = "Sharma",
                    Email = "anu.vig@test.com",
                    AreaCode = 102,
                    Address = "114,Pluto Colony",
                    Gender = "M"
                }
            };
        }


        public CustomerEntity Add(CustomerEntity customer)
        {
            var alreadyExist = GetCustomersByEmail(customer.Email);


            if (alreadyExist != null) return alreadyExist;

            customer.Id = customer.Id != default ? customer.Id : Guid.NewGuid();
            Customers.Add(customer);

            return customer;
        }

        public List<CustomerEntity> Get()
        {
            return Customers;
        }

        public CustomerEntity Get(string email)
        {
            return Customers.FirstOrDefault(p => p.Email == email);
        }

        public CustomerEntity Update(string email, CustomerEntity customer)
        {
            var existedCustomer = Get(email);
            if (existedCustomer != null)
            {
                return null;
            }
          
            var updatedCustomer = new CustomerEntity()
            {
                Address = customer.Address,
                AreaCode = customer.AreaCode,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Gender = customer.Gender,
                Id = customer.Id,
                PhoneNumber = customer.PhoneNumber
            };
            
           
            Customers.Add(updatedCustomer);
            return updatedCustomer;
        }


        public CustomerEntity GetCustomersByEmail(string email)
        {
            return Customers.FirstOrDefault(p => p.Email == email);
        }
    }
}
