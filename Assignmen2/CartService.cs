using Assignmen2.Models;
using Assignmen2.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json;

namespace Assignmen2
{

    // This class is responsible for managing the cart
    public class CartService : ICartServices
    {
        private readonly IHttpContextAccessor? _httpContextAccessor;
        private readonly ProductContext _context;
        private Cart _cart = new Cart();


        // Constructor
        public CartService(ProductContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _cart = GetCartFromSession();

        }

        // Method to get the cart
        public Cart GetCart()
        {
            return _cart;
        }
        public void AddItem(Product product, int quantity)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);

            if (item == null)
            {
                item = new Item { Product = product, Quantity = quantity };
                _cart.Items.Add(item);
            }
            else
            {
                item.Quantity += quantity;
            }
            UpdateCartInSession(Get_httpContextAccessor());
        }

        //  Method to remove an item from the cart
        private IHttpContextAccessor? Get_httpContextAccessor()
        {
            return _httpContextAccessor;
        }

        // Method to update the cart in the session
        private void UpdateCartInSession(IHttpContextAccessor? _httpContextAccessor)
        {
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(_cart));
        }

        // Method to add a product to the cart
        public void AddToCart(string productId, int quantity)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                var newItem = new Item { Product = product, Quantity = quantity };
                _cart.Items.Add(newItem);
            }
        }

        //  Method to update the cart
        public void UpdateCart(Cart cart)
        {
            _cart = cart;
            SaveCartToSession(_cart);
        }


        // Method to save the cart to the session
        private void SaveCartToSession(Cart cart)
        {
            var cartJson = JsonConvert.SerializeObject(cart);
            _httpContextAccessor.HttpContext.Session.SetString("Cart", cartJson);
        }

        // Method to get the cart from the session
        private Cart GetCartFromSession()
        {
            var cartJson = _httpContextAccessor.HttpContext.Session.GetString("Cart");

            if (!string.IsNullOrEmpty(cartJson))
            {
                return JsonConvert.DeserializeObject<Cart>(cartJson);
            }

            var cart = new Cart();
            _httpContextAccessor.HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
            return cart;
        }

        // Method to remove an item from the cart
        public void RemoveItem(string productId)
        {
            var cart = GetCart();
            var itemToRemove = cart.Items.FirstOrDefault(item => item.Product.Id == productId);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                UpdateCartInSession(Get_httpContextAccessor());

            }
        }

        // Method to clear the cart
        public void ClearCart()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Cart");
        }


    }
}
