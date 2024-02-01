using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BubbleTeaCorp.API.Entities
{
    public class BubbleTea
    {
        [Key]
        public int BubbleTeaId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Required]
        public int FlavourId { get; set; }

        [ForeignKey("FlavourId")]
        public virtual Flavour Flavour { get; set; }

        [Required]
        public int IceAmountId { get; set; }

        [ForeignKey("IceAmountId")]
        public virtual IceLevel IceAmount { get; set; }

        // Navigation property for Toppings
        public virtual List<Topping> Toppings { get; set; } = new();
    }
}