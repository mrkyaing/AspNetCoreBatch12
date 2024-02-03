namespace TOMS.Models.ViewModels
{
    public class PaymentConfirmViewModel
    {
        public string PaymentTypeId { get; set; }
        public PaymentTypeViewModel PaymentTypeInfo { get; set; }
        //for passenger info 
        public string Name { get; set; }
        public string NRC { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        //for ticket info 
        public TicketViewModel Ticket { get; set; }
        //for showing TxNo to the UI
        public string TxNo { get; set; }
    }
}
