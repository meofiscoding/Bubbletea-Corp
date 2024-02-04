using System.ComponentModel.DataAnnotations;

namespace BubbleTeaCorp.API.Entities
{
    public class Store
    {
        [Key]
        public int StoreNumber { get; set; }

        [Required]
        public string StoreName { get; set; } = string.Empty;
    }
}