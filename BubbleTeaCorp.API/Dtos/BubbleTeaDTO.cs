namespace BubbleTeaCorp.API.Dtos
{
    public class BubbleTeaDTO
    {
        public int FlavourIds { get; set; } 
        public List<int> ToppingIds { get; set; } = new List<int>();
        public int IceAmountId { get; set; }
    }
}