using BubbleTeaCorp.API.Common;
using BubbleTeaCorp.API.Dtos.Order;

namespace BubbleTeaCorp.API.Dtos
{
    public class OrderResponseDTO : CommonResponseDTO
    {
        public OrderResponse Data { get; set; } = new();
    }

    public class OrderResponse
    {
        public int OrderNumber { get; set; }

        public int StoreNumber { get; set; }

        public DateTime OrderDateTime { get; set; } = DateTime.Now;

        public List<BubbleTeaResponseDTO> BubbleTeas { get; set; } = new List<BubbleTeaResponseDTO>();

        public string TotalOrderPrice { get; set; }
    }
}