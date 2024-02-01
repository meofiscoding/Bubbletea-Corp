using System.ComponentModel.DataAnnotations;
using BubbleTeaCorp.API.Enums;

namespace BubbleTeaCorp.API.Entities
{
    public class Flavour
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        // To distinguish between customised flavours and pre-defined flavours
        [Required]
        public FlavourType Type { get; set; }

        // Navigation property for DefaultConfigurations
        public virtual List<DefaultConfiguration> DefaultConfigurations { get; set; } = new();

        // Navigation property for BubbleTeas
        public virtual List<BubbleTea> BubbleTeas { get; set; } = new();
    }
}