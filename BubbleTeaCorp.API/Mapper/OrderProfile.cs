using AutoMapper;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // mapping all element from orderDTO to Order except BubbleTeas
            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.BubbleTeas, opt => opt.Ignore());
        }
    }
}