using Shared.Clients.Models;
using System.Threading.Tasks;

namespace Shared.Clients.Interface
{
    public interface IPartnerClient
    {
        Task<Partner> GetPartner(string email);
    }
}
