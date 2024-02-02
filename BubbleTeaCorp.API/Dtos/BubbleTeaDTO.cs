using System.ComponentModel.DataAnnotations;

namespace BubbleTeaCorp.API.Dtos
{
    public class BubbleTeaDTO
    {
        [Required]
        public int FlavourId { get; set; }
        public List<int> ToppingIds { get; set; } = new List<int>();
        public int IceAmountId { get; set; }
    }
}