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
        public async Task<IActionResult> SaveOrder([FromBody] OrderDto orderDto)
        {
            try
            {
                // Validate model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var success = await _orderService.SaveOrder(orderDto);
                if (!success)
                {
                    return BadRequest("Error saving order");
                }

                return Ok("Order created successfully!!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error saving order: {ex.Message}");
            }
        }
    }
}