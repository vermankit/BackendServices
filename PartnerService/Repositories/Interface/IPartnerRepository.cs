using PartnerService.Repositories.Entity;
using System;
using System.Collections.Generic;

namespace PartnerService.Repositories.Interface
{
    public interface IPartnerRepository
    {
        PartnerEntity Add(PartnerEntity partner);
        List<PartnerEntity> Get();
        PartnerEntity Get(string email);
        PartnerEntity Update(string email, PartnerEntity partner);
    }
}