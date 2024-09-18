using Assignmen2.Models;

namespace Assignmen2.Data
{
    public static class DbInit
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products
            if (context.Products.Any())
            {
                return; // DB has been seeded
            }

            var products = new Product[]
            {
                new Product { Id = "1", Name = "Cheddar", PhotoPath = "/uploads/Cheddar.jpg", Price = 5.50, Quantity = 1,
    Description = "A sharp, firm cheese with a bold flavor. Perfect for sandwiches and snacks.", SellerId = "1" },

                new Product { Id = "2", Name = "Brie", PhotoPath = "/uploads/Brie.jpg", Price = 7.20, Quantity = 4,
    Description = "A soft cheese with a creamy interior and a mild, buttery taste.", SellerId = "2" },

                new Product { Id = "3", Name = "Gouda", PhotoPath = "/uploads/Gouda.jpg", Price = 6.30, Quantity = 4,
    Description = "A semi-hard cheese with a rich, buttery flavor and a smooth texture.", SellerId = "1" },

                new Product { Id = "4", Name = "Blue Cheese", PhotoPath = "/uploads/BlueCheese.jpg", Price = 8.40, Quantity = 5,
    Description = "A pungent, crumbly cheese with blue veins and a strong flavor.", SellerId = "2" },

                new Product { Id = "5", Name = "Mozzarella", PhotoPath = "/uploads/Mozzarella.jpg", Price = 4.90, Quantity = 8,
    Description = "A fresh, soft cheese known for its stretchy texture, ideal for pizza and salads.", SellerId = "1" },

                new Product { Id = "6", Name = "Parmesan", PhotoPath = "/uploads/Parmesan.jpg", Price = 9.50, Quantity = 10,
    Description = "A hard, aged cheese with a rich, nutty flavor. Perfect for grating over pasta.", SellerId = "2" },

                new Product { Id = "7", Name = "Feta", PhotoPath = "/uploads/Feta.jpg", Price = 5.00, Quantity = 3,
    Description = "A crumbly, salty cheese with a tangy flavor. Commonly used in Greek salads.", SellerId = "1" },

                new Product { Id = "8", Name = "Camembert", PhotoPath = "/uploads/Camembert.jpg", Price = 7.80, Quantity = 5,
    Description = "A soft cheese with a rich, buttery interior and a bloomy rind.", SellerId = "2" },

                new Product { Id = "9", Name = "Swiss", PhotoPath = "/uploads/Swiss.jpg", Price = 6.80, Quantity = 2,
    Description = "A mild, nutty cheese with characteristic holes. Often used in sandwiches.", SellerId = "1" }

            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }

        public static void Initialize(ApplicationDbContext applicationDbContext)
        {
            applicationDbContext.Database.EnsureCreated();
            // Seed data for application-related entities (like users and roles) here
        }
    }
}
