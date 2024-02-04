using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BubbleTeaCorp.API.Controllers
{
    public class BubbleTeaController : ControllerBase
    {
        private readonly ILogger<BubbleTeaController> _logger;
        private readonly IOrderService _orderService;
        private readonly IStoreService _storeService;

        public BubbleTeaController(ILogger<BubbleTeaController> logger, IOrderService orderService, IStoreService storeService)
        {
            _logger = logger;
            _orderService = orderService;
            _storeService = storeService;
        }

        [HttpPost("saveOrder")]
        public async Task<IActionResult> SaveOrder([FromBody] OrderRequestDto OrderRequestDto)
        {
            // Validate model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _orderService.SaveOrder(OrderRequestDto);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("report")]
        public List<StoreReportDTO> GetReport([FromQuery] string monthYear)
        {
            try
            {
                return _storeService.GetReport(monthYear);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting report: {ex.Message}");
            }
        }
    }
}