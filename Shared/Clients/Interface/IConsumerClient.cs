using System.Threading.Tasks;
using Shared.Clients.Models;

namespace Shared.Clients.Interface
{
    public interface IConsumerClient
    {
        Task<Customer> GetCustomer(string email);
    }
}
