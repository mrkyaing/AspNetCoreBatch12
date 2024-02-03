namespace TOMS.Models.ViewModels
{
    public class SeatPlanViewModel
    {
        public string PassengerType { get; set; }
        public string BusLineType { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public TimeSpan When { get; set; }
        public DateTime DepaturedDate { get; set; }
        public string RouteId { get; set; }
        public int NumberOfSeat { get; set; }
        public decimal UnitPrice { get; set; }
        //for available & non-available condition control 
        public List<SeatPlan>   Seats { get; set; }
    }
}
