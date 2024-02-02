using AutoMapper;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API.Mapper
{
    public class BubbleTeaProfile : Profile
    {
        public BubbleTeaProfile()
        {
            CreateMap<BubbleTeaDTO, BubbleTea>()
                .ForMember(dest => dest.BubbleTeaId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.FlavourId, opt => opt.MapFrom(src => src.FlavourId))
                .ForMember(dest => dest.IceAmountId, opt => opt.MapFrom(src => src.IceAmountId))
                .ForMember(dest => dest.Toppings, opt => opt.Ignore());
        }

    }
}