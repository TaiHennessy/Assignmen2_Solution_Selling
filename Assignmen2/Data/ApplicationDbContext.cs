using Assignmen2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignmen2.Data
{
    // ApplicationDbContext for identity management and transactions
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        // Constructor for ApplicationDbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Include Transactions DbSet
        public DbSet<Transaction> Transactions { get; set; }

        // Override OnModelCreating to seed roles, users, and configure relationships
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Users and Roles using the SeedUsersRoles helper
            SeedUsersRoles seedUsersRoles = new SeedUsersRoles();

            // Seed roles
            builder.Entity<IdentityRole>().HasData(seedUsersRoles.Roles);

            // Seed users
            builder.Entity<ApplicationUser>().HasData(seedUsersRoles.Users);

            // Seed user-role relationships
            builder.Entity<IdentityUserRole<string>>().HasData(seedUsersRoles.UserRoles);

            // Configure Transaction entity
            builder.Entity<Transaction>()
                .HasOne<ApplicationUser>(t => t.Buyer)
                .WithMany()
                .HasForeignKey(t => t.BuyerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transaction>()
                .HasOne<ApplicationUser>(t => t.Seller)
                .WithMany()
                .HasForeignKey(t => t.SellerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Specify precision for TotalAmount in Transaction
            builder.Entity<Transaction>()
                .Property(t => t.TotalAmount)
                .HasColumnType("decimal(18,2)");  // Set the precision and scale for the decimal
        }
    }

    // ProductContext for managing products
    public class ProductContext : DbContext

        // Constructor for ProductContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        // Include Products DbSet
        public DbSet<Product> Products { get; set; }

        // Configure Product entity mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
