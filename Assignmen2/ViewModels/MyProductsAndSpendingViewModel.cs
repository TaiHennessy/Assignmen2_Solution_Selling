using Assignmen2.Models;

namespace Assignmen2.ViewModels
{
    public class MyProductsAndSpendingViewModel
    {
        public IEnumerable<Product> Products { get; set; }  // List of products
        public IEnumerable<UserSpendingViewModel> UserSpendingSummary { get; set; }  // User spending summary
    }
}
