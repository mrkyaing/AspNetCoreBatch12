namespace TOMS.Models.ViewModels
{
    public class TicketViewModel
    {
        public DateTime TicketOrderedDate { get; set; }//same as DepaturedDate 
        public string PassengerType { get; set; }
        public string BusLineType { get; set; }
        public TimeSpan When { get; set; }
        public decimal UnitPrice { get; set; }
        public string RouteId { get; set; }
        public string[] SeatsNo { get; set; }
        public string[] SeatRows { get; set; }
        public string? Status { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
