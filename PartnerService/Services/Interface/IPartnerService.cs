using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PartnerService.Modals;

namespace PartnerService.Services.Interface
{
    internal interface IPartnerService
    {
        Task AddPartner(Partner partner);
        Task<List<Partner>> GetPartners();
        Task<Partner> GetPartners(Guid id);
    }
}
