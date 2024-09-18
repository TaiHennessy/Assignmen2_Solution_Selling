namespace Assignmen2.ViewModels
{
    public class OrderViewModel
    {
        public string SellerEmail { get; set; }    // The seller's email
        public int Quantity { get; set; }          // The quantity purchased
        public decimal BasePrice { get; set; }     // The base price of the product
        public decimal Commission { get; set; }    // The 10% commission on the product
        public decimal Tax { get; set; }           // The 5% tax on the product
        public decimal TotalAmount { get; set; }   // The total amount the buyer paid
        public string Status { get; set; }         // The status of the order
    }
}