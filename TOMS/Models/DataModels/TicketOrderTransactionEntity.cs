using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("TicketOrderTransaction")]
    public class TicketOrderTransactionEntity:BaseEntity
    {
        public string TnxNo { get; set; }
        public string Status { get; set; }
        public string PaymentTypeId { get; set; }
        public string PassengerId { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
        public string ScreenShootUrl { get; set; }
        public string Remark { get; set; }
    }
}
