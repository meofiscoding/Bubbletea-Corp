using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleTeaCorp.API.Common
{
    public class CommonResponseDTO
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}