using System;
using System.Collections.Generic;
using PartnerService.Modals;

namespace PartnerService.Repositories.Interface
{
    public interface IPartnerRepository
    {
        Partner Add(Partner partner);
        List<Partner> Get();
        Partner Get(Guid id);
        Partner Update(Guid id, Partner partner);
    }
}