using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BubbleTeaCorp.API.Entities
{
    public class DefaultConfiguration
    {
        [Key]
        public int DefaultConfigurationId { get; set; }

        [Required]
        public int FlavourId { get; set; }

        [ForeignKey("FlavourId")]
        public virtual Flavour Flavour { get; set; }

        [Required]
        public int DefaultToppingId { get; set; }

        [ForeignKey("DefaultToppingId")]
        public virtual Topping DefaultTopping { get; set; }

        [Required]
        public int DefaultIceLevelId { get; set; }

        [ForeignKey("DefaultIceLevelId")]
        public virtual IceLevel DefaultIceLevel { get; set; }
    }
}