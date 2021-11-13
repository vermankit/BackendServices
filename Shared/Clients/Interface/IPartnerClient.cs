using System;
using System.Threading.Tasks;

namespace Shared.Clients.Interface
{
    public interface IPartnerClient
    {
        Task<dynamic> GetPartner(Guid partnerId);
    }
}
