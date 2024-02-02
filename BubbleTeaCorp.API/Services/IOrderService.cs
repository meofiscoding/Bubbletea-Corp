using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BubbleTeaCorp.API.Dtos;

namespace BubbleTeaCorp.API.Services
{
    public interface IOrderService
    {
        Task<bool> SaveOrder(OrderDto orderDto);
    }
}