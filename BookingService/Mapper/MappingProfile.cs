using AutoMapper;
using BookingService.Modals;
using BookingService.Repositories.Entity;

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
