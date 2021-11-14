using System.Collections.Generic;
using ConsumerService.Repositories.Entity;

namespace ConsumerService.Repositories.Interface
{
    public interface ICustomerRepository
    {
        CustomerEntity Add(CustomerEntity partner);
        List<CustomerEntity> Get();
        CustomerEntity Get(string email);
        CustomerEntity Update(string email, CustomerEntity partner);
    }
}