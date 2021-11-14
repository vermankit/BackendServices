using AutoMapper;
using PartnerService.Modals;
using PartnerService.Repositories.Entity;

namespace PartnerService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PartnerEntity, Partner>().ReverseMap();
        }
    }
}
