using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> SaveOrder(OrderRequestDto OrderRequestDto);
    }
}