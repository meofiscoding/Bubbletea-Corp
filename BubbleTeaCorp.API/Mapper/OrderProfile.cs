using AutoMapper;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
        }
    }
}