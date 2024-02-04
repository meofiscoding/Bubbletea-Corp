using AutoMapper;
using BubbleTeaCorp.API.Dtos;
using BubbleTeaCorp.API.Entities;
using BubbleTeaCorp.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace BubbleTeaCorp.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly BubbleTeaDbContext _context;
        private readonly ILogger<OrderService> _logger;
        private readonly IMapper _mapper;

        public OrderService(BubbleTeaDbContext context, IMapper mapper, ILogger<OrderService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<OrderResponseDTO> SaveOrder(OrderRequestDto OrderRequestDto)
        {
            try
            {
                // validate StoreNumber if it exists in the database
                if (!_context.Stores.Any(x => x.StoreNumber == OrderRequestDto.StoreNumber))
                {
                    return new OrderResponseDTO()
                    {
                        IsSuccess = false,
                        Message = $"Store number {OrderRequestDto.StoreNumber} not found"
                    };
                }

                // Mapping between OrderRequestDto and Order
                var order = _mapper.Map<Order>(OrderRequestDto);
                // Add order to the repository
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Handle pre-defined flavour and explicitly map BubbleTeas to order
                order.BubbleTeas = await HandlePredefinedFlavour(OrderRequestDto.BubbleTeas);

                // Save bubbleTea with its orderID
                foreach (var bubbleTea in order.BubbleTeas)
                {
                    bubbleTea.OrderId = order.OrderId;
                    _context.BubbleTeas.Add(bubbleTea);
                }

                await _context.SaveChangesAsync();

                var savedOrder = _context.Orders
                        .Include(x => x.BubbleTeas)
                        .FirstOrDefault(x => x.OrderId == order.OrderId);

                return new OrderResponseDTO()
                {
                    IsSuccess = true,
                    Message = "Order saved successfully",
                    Data = _mapper.Map<OrderResponse>(savedOrder)
                };
            }
            catch (Exception ex)
            {
                return new OrderResponseDTO()
                {
                    IsSuccess = false,
                    Message = $"Error saving order due to: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Handle case when there is a bubbleTea in bubbleTeas list of order that have flavour is predefine
        /// Then get its pre-defined stuff from DefaultConfiguration table and set value to its Topping and IceLevel
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<List<BubbleTea>> HandlePredefinedFlavour(List<BubbleTeaRequestDTO> bubbleTeas)
        {
            List<BubbleTea> result = new();
            foreach (var bubbleTea in bubbleTeas)
            {
                BubbleTea cup = _mapper.Map<BubbleTea>(bubbleTea);
                // Get Flavour of cup
                cup.Flavour = await _context.Flavours
                    .FirstOrDefaultAsync(x => x.Id == bubbleTea.FlavourId)
                    ?? throw new ArgumentNullException($"Flavour with ID {bubbleTea.FlavourId} not found");

                // Case when bubbleTea is brownSugar flavour
                if (cup.Flavour.Type == FlavourType.NonCustomizable_BrownSugar)
                {
                    // Get all pre-defined configuration from DefaultConfiguration table by FlavourID
                    List<DefaultConfiguration> defaultConfiguration = await _context.DefaultConfigurations
                        .Where(x => x.FlavourId == bubbleTea.FlavourId)
                        .Include(x => x.DefaultTopping)
                        .Include(x => x.DefaultIceLevel)
                        .ToListAsync();

                    // Set value to bubbleTea
                    cup.IceAmount = defaultConfiguration.Select(x => x.DefaultIceLevel).FirstOrDefault();
                    cup.Toppings = defaultConfiguration.ConvertAll(x => x.DefaultTopping);
                }
                else
                {
                    // Normal case
                    cup.Toppings = await _context.Toppings
                        .Where(x => bubbleTea.ToppingIds.Contains(x.Id))
                        .ToListAsync();

                    cup.IceAmount = await _context.IceLevels
                        .FirstOrDefaultAsync(x => x.Id == bubbleTea.IceAmountId)
                        ?? throw new ArgumentNullException($"IceAmount with ID {bubbleTea.IceAmountId} not found");
                }
                result.Add(cup);
            }
            return result;
        }
    }
}