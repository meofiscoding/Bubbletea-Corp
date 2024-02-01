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
        private readonly IMapper _mapper;
        public OrderService(BubbleTeaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task SaveOrder(OrderDto orderDto)
        {
            // Mapping between OrderDto and Order
            var order = _mapper.Map<Order>(orderDto);

            // Handle pre-defined flavour
            order = await HandlePredefinedFlavour(order);

            // Save order to the repository
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Handle case when there is a bubbleTea in bubbleTeas list of order that have flavour is predefine
        /// Then get its pre-defined stuff from DefaultConfiguration table and set value to its Topping and IceLevel
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<Order> HandlePredefinedFlavour(Order order)
        {
            foreach (var bubbleTea in order.BubbleTeas)
            {
                // Case when bubbleTea is brownSugar flavour
                if (bubbleTea.Flavour.Type == FlavourType.NonCustomizable_BrownSugar)
                {
                    // Get all pre-defined configuration from DefaultConfiguration table by FlavourID
                    List<DefaultConfiguration> defaultConfiguration = await _context.DefaultConfigurations
                        .Where(x => x.FlavourId == bubbleTea.FlavourId)
                        .ToListAsync();

                    // Set value to bubbleTea
                    bubbleTea.IceAmountId = defaultConfiguration.Select(x => x.DefaultIceLevelId).FirstOrDefault();
                    bubbleTea.Toppings = defaultConfiguration.ConvertAll(x => x.DefaultTopping);
                }
            }
            return order;
        }
    }
}