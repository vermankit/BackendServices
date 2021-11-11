using ConsumerService.Modals;
using System;
using System.Collections.Generic;

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
