using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options): base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 1, CategoryName = "Sword"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 2, CategoryName = "Shield" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryID = 3, CategoryName = "Potion"});


            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 1, CategoryID = 1, ItemName = "Wooden Sword", ItemPrice = 1 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 2, CategoryID = 1, ItemName = "Stone Sword", ItemPrice = 5.5m });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 3, CategoryID = 1, ItemName = "Iron Sword", ItemPrice = 10 });

            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 4, CategoryID = 2, ItemName = "Wooden Shield", ItemPrice = 5 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 5, CategoryID = 2, ItemName = "Iron Shield", ItemPrice = 7.8m });

            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 6, CategoryID = 3, ItemName = "Regeneration potion", ItemPrice = 15 });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 7, CategoryID = 3, ItemName = "Strength potion", ItemPrice = 10.3m });
        }
    }
}
