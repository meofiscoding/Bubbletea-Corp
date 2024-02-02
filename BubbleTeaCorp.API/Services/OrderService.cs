using System.Collections.Generic;
using AutoMapper;
using BubbleTeaCorp.API.Controllers;
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
        public async Task<bool> SaveOrder(OrderDto orderDto)
        {
            try
            {
                // Mapping between OrderDto and Order
                var order = _mapper.Map<Order>(orderDto);
                // Add order to the repository
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                // Handle pre-defined flavour
                List<BubbleTea> bubbleTeas = await HandlePredefinedFlavour(orderDto.BubbleTeas);
                // Save bubbleTea with its orderID
                foreach (var bubbleTea in order.BubbleTeas)
                {
                    bubbleTea.OrderId = order.OrderId;
                    _context.BubbleTeas.Add(bubbleTea);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Log error
                _logger.LogError($"Error saving order due to: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Handle case when there is a bubbleTea in bubbleTeas list of order that have flavour is predefine
        /// Then get its pre-defined stuff from DefaultConfiguration table and set value to its Topping and IceLevel
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<List<BubbleTea>> HandlePredefinedFlavour(List<BubbleTeaDTO> bubbleTeas)
        {
            List<BubbleTea> result = new();
            foreach (var bubbleTea in bubbleTeas)
            {
                BubbleTea cup = _mapper.Map<BubbleTea>(bubbleTea);
                // Get flavor by flavourID
                cup.Flavour = await _context.Flavours
                    .FirstOrDefaultAsync(x => x.Id == bubbleTea.FlavourId)
                    ?? throw new ArgumentNullException($"Flavour with ID {bubbleTea.FlavourId} not found");
                cup.Toppings = await _context.Toppings
                    .Where(x => bubbleTea.ToppingIds.Contains(x.Id))
                    .ToListAsync();
                // Case when bubbleTea is brownSugar flavour
                if (cup.Flavour.Type == FlavourType.NonCustomizable_BrownSugar)
                {
                    // Get all pre-defined configuration from DefaultConfiguration table by FlavourID
                    List<DefaultConfiguration> defaultConfiguration = await _context.DefaultConfigurations
                        .Where(x => x.FlavourId == bubbleTea.FlavourId)
                        .Include(x => x.DefaultTopping)
                        .ToListAsync();

                    // Set value to bubbleTea
                    cup.IceAmountId = defaultConfiguration.Select(x => x.DefaultIceLevelId).FirstOrDefault();
                    cup.Toppings = defaultConfiguration.ConvertAll(x => x.DefaultTopping);
                }
                result.Add(cup);
            }
            return result;
        }
    }
}