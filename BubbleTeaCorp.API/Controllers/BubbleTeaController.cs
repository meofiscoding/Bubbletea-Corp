using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BubbleTeaCorp.API.Controllers
{
    public class BubbleTeaController : ControllerBase
    {
        private readonly ILogger<BubbleTeaController> _logger;
        private readonly IOrderService _orderService;

        public BubbleTeaController(ILogger<BubbleTeaController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
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
    }
}