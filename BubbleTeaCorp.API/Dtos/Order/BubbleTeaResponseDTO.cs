using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleTeaCorp.API.Dtos.Order
{
    public class BubbleTeaResponseDTO
    {
        public string Flavour { get; set; } = string.Empty;

        public string IceLevel { get; set; } = string.Empty;

        public List<string> Toppings { get; set; } = new();
    }
}