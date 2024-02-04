namespace BubbleTeaCorp.API.Dtos
{
    public class OrderRequestDto
    {
        /* Params based on requirement: tore number, 
                order number, order date time, flavours,
                toppings, amount of ice and the total order price.
        */
        public int StoreNumber { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        public List<BubbleTeaRequestDTO> BubbleTeas { get; set; } = new List<BubbleTeaRequestDTO>();
        public decimal TotalOrderPrice { get; set; }
    }
}