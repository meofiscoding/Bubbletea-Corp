using BubbleTeaCorp.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BubbleTeaCorp.API
{
    public class BubbleTeaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("BubbleteaDB");
        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Flavour> Flavours { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<IceLevel> IceLevels { get; set; }
        public DbSet<BubbleTea> BubbleTeas { get; set; }
        public DbSet<DefaultConfiguration> DefaultConfigurations { get; set; }
    }
}