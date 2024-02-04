using AutoMapper;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // mapping all element from OrderRequestDto to Order except BubbleTeas
            CreateMap<OrderRequestDto, Order>()
                .ForMember(dest => dest.BubbleTeas, opt => opt.Ignore());

            CreateMap<Order, OrderResponse>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.StoreNumber, opt => opt.MapFrom(src => src.StoreNumber))
                .ForMember(dest => dest.OrderDateTime, opt => opt.MapFrom(src => src.OrderDateTime))
                .ForMember(dest => dest.BubbleTeas, opt => opt.MapFrom(src => src.BubbleTeas))
                .ForMember(dest => dest.TotalOrderPrice, opt => opt.MapFrom(src => $"{src.TotalOrderPrice}$"));
        }
    }
}