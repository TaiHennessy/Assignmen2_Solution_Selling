using Assignmen2.Models;

namespace Assignmen2
{
    public interface ICartServices
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(string productId);
        void ClearCart();
        Cart GetCart();
        void UpdateCart(Cart cart);
    }
}
