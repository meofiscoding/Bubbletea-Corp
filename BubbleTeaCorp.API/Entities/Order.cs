using System.ComponentModel.DataAnnotations;

namespace BubbleTeaCorp.API.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int StoreNumber { get; set; }

        [Required]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public decimal TotalOrderPrice { get; set; }

        // Navigation property for BubbleTeas
        public virtual List<BubbleTea> BubbleTeas { get; set; } = new();
    }
}