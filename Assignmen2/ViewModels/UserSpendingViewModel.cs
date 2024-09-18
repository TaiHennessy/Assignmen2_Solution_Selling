namespace Assignmen2.ViewModels
{
    public class UserSpendingViewModel
    {
        public string UserId { get; set; }           // The ID of the user
        public string UserEmail { get; set; }        // The email of the user
        public decimal TotalSpent { get; set; }      // Total amount the user has spent
        public decimal TotalCommissionPaid { get; set; }  // Total commission paid by the user (10%)
        public decimal TotalTaxPaid { get; set; }    // Total tax paid by the user (5%)
    }
}
