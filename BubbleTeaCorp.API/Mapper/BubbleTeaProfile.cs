using AutoMapper;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Dtos.Order;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API.Mapper
{
    public class BubbleTeaProfile : Profile
    {
        public BubbleTeaProfile()
        {
            CreateMap<BubbleTeaRequestDTO, BubbleTea>()
                .ForMember(dest => dest.BubbleTeaId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.Order, opt => opt.Ignore())
                .ForMember(dest => dest.Flavour, opt => opt.Ignore())
                .ForMember(dest => dest.IceAmount, opt => opt.Ignore())
                .ForMember(dest => dest.FlavourId, opt => opt.MapFrom(src => src.FlavourId))
                .ForMember(dest => dest.IceAmountId, opt => opt.MapFrom(src => src.IceAmountId))
                .ForMember(dest => dest.Toppings, opt => opt.Ignore());

            CreateMap<BubbleTea, BubbleTeaResponseDTO>()
                .ForMember(dest => dest.Flavour, opt => opt.MapFrom(src => src.Flavour.Name))
                .ForMember(dest => dest.IceLevel, opt => opt.MapFrom(src => src.IceAmount.IceAmount))
                .ForMember(dest => dest.Toppings, opt => opt.MapFrom(src => src.Toppings.ConvertAll(x => x.Name)));
        }
    }
}