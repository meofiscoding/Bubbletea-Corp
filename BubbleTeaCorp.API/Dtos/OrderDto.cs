namespace BubbleTeaCorp.API.Dtos
{
    public class OrderDto
    {
        /* Params based on requirement: tore number, 
                order number, order date time, flavours,
                toppings, amount of ice and the total order price.
        */
        public int StoreNumber { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDateTime { get; set; } = DateTime.Now;
        public List<BubbleTeaDTO> BubbleTeas { get; set; } = new List<BubbleTeaDTO>();
        public decimal TotalOrderPrice { get; set; }
    }
}