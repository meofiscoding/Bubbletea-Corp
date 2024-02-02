using BubbleTeaCorp.API.Entities;
using BubbleTeaCorp.API.Enums;

namespace BubbleTeaCorp.API
{
    public static class SeedData
    {
        public static void Initialize(BubbleTeaDbContext context)
        {
            context.Database.EnsureCreated(); // Ensure that the database is created

            // Seed IceLevel
            if (!context.IceLevels.Any())
            {
                context.IceLevels.AddRange(
                    new IceLevel { IceAmount = "Full" },
                    new IceLevel { IceAmount = "Half" },
                    new IceLevel { IceAmount = "None" }
                );
                context.SaveChanges();
            }

            // Seed Flavour
            if (!context.Flavours.Any())
            {
                context.Flavours.AddRange(
                    new Flavour { Name = "Milk Tea", Type = FlavourType.Customizable },
                    new Flavour { Name = "Premium Milk Tea", Type = FlavourType.Customizable },
                    new Flavour { Name = "Lychee", Type = FlavourType.Customizable },
                    new Flavour { Name = "Brown Sugar", Type = FlavourType.NonCustomizable_BrownSugar }
                );
                context.SaveChanges();
            }

            // Seed Topping
            if (!context.Toppings.Any())
            {
                context.Toppings.AddRange(
                    new Topping { Name = "Tapioca Pearls" },
                    new Topping { Name = "Jelly" },
                    new Topping { Name = "Cream Top" },
                    new Topping { Name = "Oreo" }
                );
                context.SaveChanges();
            }

            // Seed DefaultConfiguration
            if (!context.DefaultConfigurations.Any())
            {
                context.DefaultConfigurations.Add(
                    new DefaultConfiguration
                    {
                        FlavourId = context.Flavours.First(f => f.Name == "Brown Sugar").Id,
                        DefaultIceLevelId = context.IceLevels.First(i => i.IceAmount == "Full").Id,
                        DefaultToppingId = context.Toppings.First(t => t.Name == "Tapioca Pearls").Id
                    }
                );
                context.SaveChanges();
            }
        }
    }
}