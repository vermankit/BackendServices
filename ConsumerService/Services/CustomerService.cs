<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsumerService.Modals;
using ConsumerService.Services.Interface;
=======
﻿using ConsumerService.Modals;
using ConsumerService.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1

namespace ConsumerService.Services
{
    public class CustomerService : ICustomerService
    {
<<<<<<< HEAD
=======
        public static List<Customer> Customers { get; set; }

>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
        static CustomerService()
        {
            Customers = new List<Customer>
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
<<<<<<< HEAD
=======

>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
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

<<<<<<< HEAD
        public static List<Customer> Customers { get; set; }

=======
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
        public Customer Add(Customer customer)
        {
            var alreadyExist = GetCustomersByEmail(customer.Email);

<<<<<<< HEAD
            if (alreadyExist != null) return alreadyExist;
=======
            if (alreadyExist != null)
            {
                return alreadyExist;
            }
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1

            customer.Id = customer.Id != default ? customer.Id : Guid.NewGuid();
            Customers.Add(customer);

            return customer;
        }

        public List<Customer> Get()
        {
            return Customers;
        }

        public Customer Get(Guid id)
        {
            return Customers.FirstOrDefault(p => p.Id == id);
        }

<<<<<<< HEAD
=======
        public Customer GetCustomersByEmail(string email)
        {
            return Customers.FirstOrDefault(p => p.Email == email);
        }

>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
        public Customer Update(Guid id, Customer customer)
        {
            Customers.Remove(customer);
            var updatedCustomer = new Customer(id, customer);
            Customers.Add(updatedCustomer);
            return updatedCustomer;
        }
<<<<<<< HEAD

        public Customer GetCustomersByEmail(string email)
        {
            return Customers.FirstOrDefault(p => p.Email == email);
        }
    }
}
=======
    }
}
>>>>>>> b0c4ad5ecb398d69837623994375c1dd471135b1
