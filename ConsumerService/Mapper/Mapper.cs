using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConsumerService.Modals;
using ConsumerService.Repositories.Entity;

namespace ConsumerService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerEntity>().ReverseMap();
        }
    }
}
