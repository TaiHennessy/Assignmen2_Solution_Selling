namespace Assignmen2.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public string SellerId { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime TransactionDate { get; set; } // Add TransactionDate property

        public ApplicationUser Buyer { get; set; } // Navigation property for buyer
        public ApplicationUser Seller { get; set; } // Navigation property for seller
    }



}
