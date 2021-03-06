using PartnerService.Enum;
using PartnerService.Repositories.Entity;
using PartnerService.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<PartnerEntity> GetByAreaCode(int areaCode)
        {
            return PartnerEntities.Where(p => p.AreaCode == areaCode).ToList();
        }

        public PartnerEntity Update(string email, PartnerEntity partnerEntity)
        {
            var existedCustomer = Get(email);
            if (existedCustomer == null)
            {
                return null;
            }

            var updatedCustomer = new PartnerEntity()
            {
                AreaCode = partnerEntity.AreaCode,
                FirstName = partnerEntity.FirstName,
                LastName = partnerEntity.LastName,
                Gender = partnerEntity.Gender,
                Id = existedCustomer.Id,
                Email = partnerEntity.Email,
                Profession = partnerEntity.Profession
            };

            var findIndex = PartnerEntities.FindIndex(i => i.Id == existedCustomer.Id);
            PartnerEntities.RemoveAt(findIndex);
            PartnerEntities.Add(updatedCustomer);
            return updatedCustomer;
        }

        public PartnerEntity GetPartnerEntityByEmail(string email)
        {
            return PartnerEntities.FirstOrDefault(p => p.Email == email);
        }
    }
}