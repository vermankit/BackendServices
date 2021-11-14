﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsumerService.Modals;
using ConsumerService.Repository.Interface;

namespace ConsumerService.Repository
{
    public class CustomerRepository : ICustomerRepository
    {

        public static List<Customer> Customers { get; set; }


        static CustomerRepository()
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


        public Customer Add(Customer customer)
        {
            var alreadyExist = GetCustomersByEmail(customer.Email);


            if (alreadyExist != null) return alreadyExist;

           


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

        public Customer Update(Guid id, Customer customer)
        {
            Customers.Remove(customer);
            var updatedCustomer = new Customer(id, customer);
            Customers.Add(updatedCustomer);
            return updatedCustomer;
        }


        public Customer GetCustomersByEmail(string email)
        {
            return Customers.FirstOrDefault(p => p.Email == email);
        }
    }
}