using Shared.Clients.Models;
using System.Threading.Tasks;

namespace Shared.Clients.Interface
{
    public interface IConsumerClient
    {
        Task<Customer> GetCustomer(string email);
    }
}
