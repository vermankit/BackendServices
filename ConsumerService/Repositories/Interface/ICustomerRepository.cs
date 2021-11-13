using System;
using System.Collections.Generic;
using ConsumerService.Modals;

namespace ConsumerService.Repository.Interface
{
    public interface ICustomerRepository
    {
        Customer Add(Customer partner);
        List<Customer> Get();
        Customer Get(Guid id);
        Customer Update(Guid id, Customer partner);
    }
}