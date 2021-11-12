using System;
using System.Collections.Generic;
using PartnerService.Modals;

namespace PartnerService.Services.Interface
{
    public interface IPartnerService
    {
        Partner Add(Partner partner);
        List<Partner> Get();
        Partner Get(Guid id);
        Partner Update(Guid id, Partner partner);
    }
}