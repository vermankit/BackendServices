﻿using System;
using System.Collections.Generic;
using System.Linq;
using PartnerService.Enum;
using PartnerService.Modals;
using PartnerService.Repositories.Interface;

namespace PartnerService.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        static PartnerRepository()
        {
            Partners = new List<Partner>()

            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Email = "saurav@test.com",
                    FirstName = "Saurav",
                    LastName = "Singh",
                    Gender = "M",
                    AreaCode = 101,
                    Profession = Service.Carpenter
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Email = "rani@test.com",
                    FirstName = "Rani",
                    LastName = "Singh",
                    Gender = "M",
                    AreaCode = 102,
                    Profession = Service.Cook
                }
            };
        }

        public static List<Partner> Partners { get; set; }

        public Partner Add(Partner partner)
        {
            var alreadyExist = GetPartnersByEmail(partner.Email);

            if (alreadyExist != null) return alreadyExist;

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

        public Partner Update(Guid id, Partner partner)
        {
            Partners.Remove(partner);
            var updatedPartner = new Partner(id, partner);
            Partners.Add(updatedPartner);
            return updatedPartner;
        }

        public Partner GetPartnersByEmail(string email)
        {
            return Partners.FirstOrDefault(p => p.Email == email);
        }
    }
}