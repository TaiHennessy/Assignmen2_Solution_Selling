namespace Assignmen2.Models
{
    public class ProductWithSeller
    {
        public Product Product { get; set; }
        public ApplicationUser Seller { get; set; }
    }
}
