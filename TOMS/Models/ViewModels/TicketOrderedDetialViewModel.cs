namespace TOMS.Models.ViewModels
{
    public class TicketOrderedDetialViewModel
    {
        public DateTime TicketOrderedDate { get; set; }//same as DepaturedDate 
        public string PassengerType { get; set; }
        public string BusLineType { get; set; }
        public TimeSpan When { get; set; }
        public decimal UnitPrice { get; set; }
        public string RouteId { get; set; }
        public string SeatNo { get; set; }
        public string SeatRow { get; set; }
        public string? Status { get; set; }
    }
}
