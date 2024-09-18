using Assignmen2.Data;
using Microsoft.AspNetCore.Mvc;
using Assignmen2.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Assignmen2.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices _cartService;
        private readonly ProductContext _context;
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public CartController(ICartServices cartService, ProductContext context, UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext)
        {
            _cartService = cartService;
            _context = context;
            _userManager = userManager; // Make sure this is assigned
            _appDbContext = applicationDbContext;
        }


        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartViewModel model)
        {
            // Debugging: Log or inspect the received data
            Console.WriteLine($"Product ID: {model.ProductId}, Quantity: {model.Quantity}");

            if (model == null)
            {
                return BadRequest("Model is null.");
            }

            if (string.IsNullOrEmpty(model.ProductId))
            {
                return BadRequest("Invalid product ID.");
            }

            if (model.Quantity <= 0)
            {
                return BadRequest("Invalid quantity.");
            }

            var product = await _context.Products.FindAsync(model.ProductId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // If it passes all checks, proceed with adding to the cart
            var cart = _cartService.GetCart();
            var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == model.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += model.Quantity;
                _cartService.UpdateCart(cart);
                return Json(new { updated = true });
            }

            _cartService.AddItem(product, model.Quantity);
            _cartService.UpdateCart(cart);

            return Json(new { updated = false });
        }

        // Simplified buy method to add a product directly to the cart
        public async Task<IActionResult> Buy(string id, int quantity = 1)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid product ID.");
            }

            if (quantity <= 0)
            {
                return BadRequest("Quantity must be at least 1.");
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Get the current cart
            var cart = _cartService.GetCart();
            var existingItem = cart.Items.FirstOrDefault(item => item.Product.Id == id);

            // Calculate the available quantity if the product is already in the cart
            int availableQuantity = product.Quantity;
            if (existingItem != null)
            {
                availableQuantity -= existingItem.Quantity;
            }

            // Ensure the total quantity requested does not exceed available stock
            if (quantity > availableQuantity)
            {
                return BadRequest("Not enough stock available.");
            }

            // If the product is already in the cart, update its quantity
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                // Add a new item to the cart
                _cartService.AddItem(product, quantity);
            }

            // If the request comes from the Details page (GET request via a form submission), redirect to the cart page
            if (HttpContext.Request.Method == "GET")
            {
                return RedirectToAction("Index", "Cart"); // Redirect to the cart page after adding the product
            }

            // Update the cart
            _cartService.UpdateCart(cart);

            return Json(new { success = true });
        }



        // Clear the cart
        public IActionResult Clear()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index", "Cart");
        }


        // Remove an item from the cart
        public IActionResult Remove(string productid)
        {
            _cartService.RemoveItem(productid);
            return RedirectToAction("Index", "Cart");
        }


        // Complete the purchase process
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinishPurchase()
        {
            var userId = _userManager.GetUserId(User);
            var cart = _cartService.GetCart();

            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            // Group by seller and calculate total spent per seller, including tax and commission
            var sellerTransactions = cart.Items
                .GroupBy(i => i.Product.SellerId)
                .Select(g => new
                {
                    SellerId = g.Key,
                    // Calculate total amount for each seller's products in the cart
                    // Apply 10% commission and 5% tax to the total amount
                    TotalAmount = g.Sum(i =>
                    {
                        decimal productTotal = (decimal)i.Product.Price * i.Quantity;
                        decimal commission = productTotal * 0.10m; // 10% commission
                        decimal tax = productTotal * 0.05m; // 5% tax
                        return productTotal + commission + tax;
                    })
                }).ToList();

            // Store transactions in the database
            foreach (var sellerTransaction in sellerTransactions)
            {
                var transaction = new Transaction
                {
                    BuyerId = userId,
                    SellerId = sellerTransaction.SellerId,
                    TotalAmount = sellerTransaction.TotalAmount
                };
                _appDbContext.Transactions.Add(transaction);
            }

            // Update product quantities
            foreach (var item in cart.Items)
            {
                var product = await _context.Products.FindAsync(item.Product.Id);
                if (product != null)
                {
                    // Reduce the product quantity
                    product.Quantity -= item.Quantity;

                    if (product.Quantity < 0)
                    {
                        // Ensure the quantity doesn't go below zero
                        product.Quantity = 0;
                    }

                    _context.Products.Update(product);
                }
            }

            // Save the changes for both transactions and products
            await _appDbContext.SaveChangesAsync();
            await _context.SaveChangesAsync();

            // Clear the cart after purchase
            _cartService.ClearCart();

            // Redirect to the purchase report page with the transaction details
            return RedirectToAction("PurchaseReport", new { userId = userId });
        }



        // Display purchase report for a user
        public async Task<IActionResult> PurchaseReport(string userId)
        {
            var transactions = await _appDbContext.Transactions
                .Where(t => t.BuyerId == userId)
                .ToListAsync();

            return View(transactions);
        }
    }
}
