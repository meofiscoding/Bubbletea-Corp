using System.Text.Json;
using BubbleTeaCorp.API.Entities;

namespace BubbleTeaCorp.API
{
    public static class SeedData
    {
        public static void Initialize(BubbleTeaDbContext context)
        {
            context.Database.EnsureCreated(); // Ensure that the database is created
            // Read all data from data.json
            var data = File.ReadAllText("data.json");

            if (!context.Stores.Any())
            {
                // Extract the Stores section
                Store[] stores = ExtractJsonDataBySection<Store>(data, nameof(context.Stores));
                context.Stores.AddRange(stores);
                context.SaveChanges();
            }
            // Seed IceLevel
            if (!context.IceLevels.Any())
            {
                IceLevel[] iceLevels = ExtractJsonDataBySection<IceLevel>(data, nameof(context.IceLevels));
                context.IceLevels.AddRange(iceLevels);
                context.SaveChanges();
            }

            // Seed Flavour
            if (!context.Flavours.Any())
            {
                Flavour[] flavours = ExtractJsonDataBySection<Flavour>(data, nameof(context.Flavours));
                context.Flavours.AddRange(flavours);
                context.SaveChanges();
            }

            // Seed Topping
            if (!context.Toppings.Any())
            {
                Topping[] topping = ExtractJsonDataBySection<Topping>(data, nameof(context.Toppings));
                context.Toppings.AddRange(topping);
                context.SaveChanges();
            }

            // Seed DefaultConfiguration
            if (!context.DefaultConfigurations.Any())
            {
                DefaultConfiguration[] defaultConfigurations = ExtractJsonDataBySection<DefaultConfiguration>(data, nameof(context.DefaultConfigurations));
                context.DefaultConfigurations.AddRange(defaultConfigurations);
                context.SaveChanges();
            }
        }

        private static T[]? ExtractJsonDataBySection<T>(string data, string sectionName)
        {
            var resultData = JsonSerializer.Deserialize<JsonElement>(data).GetProperty(sectionName).ToString();
            return JsonSerializer.Deserialize<T[]>(resultData);
        }
    }
}