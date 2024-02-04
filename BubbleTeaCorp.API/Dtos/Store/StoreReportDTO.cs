using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BubbleTeaCorp.API.Dtos
{
    public class StoreReportDTO
    {
        public int StoreNumber { get; set; }
        public string OrderPriceSum { get; set; }
        public int OrderTotal { get; set; }
    }
}