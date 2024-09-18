using Assignmen2.Data;
using Assignmen2.Models; // For Product and ApplicationUser models
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Assignmen2.Services
{
    public class ProductService
    {
        private readonly ProductContext _productContext; //ProductContext
        private readonly ApplicationDbContext _userContext; //ApplicationDbContext

        // Constructor injection for both DbContexts
        public ProductService(ProductContext productContext, ApplicationDbContext userContext)
        {
            _productContext = productContext;
            _userContext = userContext;
        }

        // Method to add a product with seller consistency check
        public async Task AddProductAsync(Product model)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // Check if the seller (user) exists in ApplicationDbContext
                var seller = await _userContext.Users.FindAsync(model.SellerId);
                if (seller == null)
                {
                    throw new Exception("Seller does not exist.");
                }

                // Add the product in ProductContext
                _productContext.Products.Add(model);
                await _productContext.SaveChangesAsync();

                // Complete the transaction only after both operations are successful
                transaction.Complete();
            }
        }

        // Method to fetch all products
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        // Method to search products by name
        public async Task<List<Product>> SearchProductsAsync(string query)
        {
            return await _productContext.Products
                .Where(p => p.Name.Contains(query))
                .ToListAsync();
        }

        // Method to fetch product by ID
        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        // Method to update a product
        public async Task UpdateProductAsync(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();
        }

        // Method to delete a product
        public async Task DeleteProductAsync(string id)
        {
            var product = await _productContext.Products.FindAsync(id);
            if (product != null)
            {
                _productContext.Products.Remove(product);
                await _productContext.SaveChangesAsync();
            }
        }

        // Method to check if a product exists by ID
        public async Task<bool> ProductExistsAsync(string id)
        {
            return await _productContext.Products.AnyAsync(e => e.Id == id);
        }

        // Method to fetch product with seller info
        public async Task<ProductWithSeller> GetProductWithSellerAsync(string productId)
        {
            // Fetch product from ProductContext
            var product = await _productContext.Products.FindAsync(productId);
            if (product == null) return null;

            // Fetch seller from ApplicationDbContext
            var seller = await _userContext.Users.FindAsync(product.SellerId);

            return new ProductWithSeller
            {
                Product = product,
                Seller = seller
            };
        }

        //Method tp get Products by SellerId (for "My Products" page)
        public async Task<List<Product>> GetProductsBySellerIdAsync(string sellerId)
        {
            // Fetch all products where the SellerId matches the given sellerId
            return await _productContext.Products
                .Where(p => p.SellerId == sellerId)
                .ToListAsync();
        }
    }
}
