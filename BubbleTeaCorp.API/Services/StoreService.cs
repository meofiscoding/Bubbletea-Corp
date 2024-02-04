using BubbleTeaCorp.API.Dtos;

namespace BubbleTeaCorp.API.Services
{
    public class StoreService : IStoreService
    {
        private readonly BubbleTeaDbContext _context;
        private readonly ILogger<OrderService> _logger;

        public StoreService(BubbleTeaDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<StoreReportDTO> GetReport(string monthYear)
        {
            var orders = _context.Orders.ToList();
            // Get all order group by StoreNumber in Order table
            // Then calculate sum of all TotalOrderPrice 
            // Calculate total number order
            var result = _context.Orders
                .Where(o => o.OrderDateTime.ToString("yyyy-MM") == monthYear) 
                .GroupBy(o => o.StoreNumber)
                .Select(g => new StoreReportDTO
                {
                    StoreNumber = g.Key,
                    OrderPriceSum = g.Sum(o => o.TotalOrderPrice),
                    OrderTotal = g.Count()
                }).ToList();

            return result;
        }
    }
}