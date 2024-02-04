using System.ComponentModel.DataAnnotations;

namespace BubbleTeaCorp.API.Entities
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        // Navigation property for BubbleTeas
        public virtual List<BubbleTea> BubbleTeas { get; set; } = new();

        // Navigation property for DefaultConfigurations
        public virtual List<DefaultConfiguration> DefaultConfigurations { get; set; } = new();
    }
}