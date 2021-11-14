using System;
using System.Collections.Generic;
using System.Linq;
using PartnerService.Enum;
using PartnerService.Repositories.Entity;
using PartnerService.Repositories.Interface;

namespace PartnerService.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        static PartnerRepository()
        {
            PartnerEntities = new List<PartnerEntity>()

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

        public static List<PartnerEntity> PartnerEntities { get; set; }

        public PartnerEntity Add(PartnerEntity partnerEntity)
        {
            var alreadyExist = GetPartnerEntityByEmail(partnerEntity.Email);

            if (alreadyExist != null) return alreadyExist;

            partnerEntity.Id = partnerEntity.Id != default ? partnerEntity.Id : Guid.NewGuid();
            PartnerEntities.Add(partnerEntity);

            return partnerEntity;
        }

        public List<PartnerEntity> Get()
        {
            return PartnerEntities;
        }

        public PartnerEntity Get(string email)
        {
            return PartnerEntities.FirstOrDefault(p => p.Email == email);
        }

        public PartnerEntity Update(string email, PartnerEntity partnerEntity)
        {
            var existedCustomer = Get(email);
            if (existedCustomer != null)
            {
                return null;
            }

            var updatedCustomer = new PartnerEntity()
            {
                AreaCode = partnerEntity.AreaCode,
                FirstName = partnerEntity.FirstName,
                LastName = partnerEntity.LastName,
                Gender = partnerEntity.Gender,
                Id = partnerEntity.Id
            };


            PartnerEntities.Add(updatedCustomer);
            return updatedCustomer;
        }

        public PartnerEntity GetPartnerEntityByEmail(string email)
        {
            return PartnerEntities.FirstOrDefault(p => p.Email == email);
        }
    }
}