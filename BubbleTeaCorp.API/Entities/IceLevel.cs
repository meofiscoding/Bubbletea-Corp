using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleTeaCorp.API.Entities
{
    public class IceLevel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IceAmount { get; set; } = string.Empty;

        // Navigation property for BubbleTeas
        public virtual List<BubbleTea> BubbleTeas { get; set; } = new();

        // Navigation property for DefaultConfigurations
        public virtual List<DefaultConfiguration> DefaultConfigurations { get; set; } = new();
    }
}