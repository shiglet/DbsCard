using AutoMapper;
using DbsCard.Models.Dto;
using DbsCard.Models.Entities;

namespace DbsCard.Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Card, CardDto>().ForMember(dto => dto.AwakenedSide, cfg => cfg.MapFrom(c => c.SideCard));
            CreateMap<CardDto, Card>().ForMember(c => c.SideCard, cfg => cfg.MapFrom(c => c.AwakenedSide));
            CreateMap<TcgData, TcgDataDto>();
            CreateMap<TcgDataDto, TcgData>();
        }
    }
}
