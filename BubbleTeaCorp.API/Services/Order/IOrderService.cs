using BubbleTeaCorp.API.Dtos;

namespace BubbleTeaCorp.API.Services
{
    public interface IOrderService
    {
        Task<OrderResponseDTO> SaveOrder(OrderRequestDto OrderRequestDto);
    }
}