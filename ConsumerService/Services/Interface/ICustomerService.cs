using System;
using System.Collections.Generic;
using ConsumerService.Modals;

namespace ConsumerService.Services.Interface
{
    public interface ICustomerService
    {
        Customer Add(Customer partner);
        List<Customer> Get();
        Customer Get(Guid id);
        Customer Update(Guid id, Customer partner);
    }
}