using PartnerService.Repositories.Entity;
using System.Collections.Generic;

namespace PartnerService.Repositories.Interface
{
    public interface IPartnerRepository
    {
        PartnerEntity Add(PartnerEntity partner);
        List<PartnerEntity> Get();
        PartnerEntity Get(string email);
        List<PartnerEntity> GetByAreaCode(int areaCode);
        PartnerEntity Update(string email, PartnerEntity partner);
    }
}