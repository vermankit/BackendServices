using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookingService.Modals;
using BookingService.Services.Entity;

namespace BookingService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingEntity, Booking>().ReverseMap(); //Map from Developer Object to DeveloperDTO Object
        }
    }
}
