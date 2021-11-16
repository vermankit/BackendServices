using System.Threading.Tasks;
using Shared.Clients.Models;

namespace Shared.Clients.Interface
{
    public interface IPartnerClient
    {
        Task<Partner> GetPartner(string email);
    }
}
