using PartnerService.Modals;
using PartnerService.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PartnerService.Services
{
    public class PartnerService : IPartnerService
    {
        public static List<Partner> Partners { get; set; }

        static PartnerService()
        {
            Partners = new List<Partner>();
        }

        public Partner Add(Partner partner)
        {
            var alreadyExist = GetPartnersByEmail(partner.Email);

            if (alreadyExist != null)
            {
                return alreadyExist;
            }

            partner.Id = partner.Id != default ? partner.Id : Guid.NewGuid();
            Partners.Add(partner);

            return partner;
        }

        public List<Partner> Get()
        {
            return Partners;
        }

        public Partner Get(Guid id)
        {
            return Partners.FirstOrDefault(p => p.Id == id);
        }

        public Partner GetPartnersByEmail(string email)
        {
            return Partners.FirstOrDefault(p => p.Email == email);
        }

        public Partner Update(Guid id, Partner partner)
        {
            Partners.Remove(partner);
            var updatedPartner = new Partner(id, partner);
            Partners.Add(updatedPartner);
            return updatedPartner;
        }
    }
}
