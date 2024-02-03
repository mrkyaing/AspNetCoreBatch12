namespace TOMS.Models.ViewModels
{
    public class OrderTransactionViewModel
    {
        public string Id { get; set; }
        public string TnxNo { get; set; }
        public string Status { get; set; }
        public string PaymentMethodId { get; set; }
        public string PassengerId { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }
    }
}
