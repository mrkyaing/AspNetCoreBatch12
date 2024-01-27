namespace TOMS.Models.ViewModels
{
    public class SearchRouteResultViewModel
    {
        public string PassengerType { get; set; }
        public DateTime DepaturedDate { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public int NumberOfSeat { get; set; }
        public string RouteId { get; set; }
        public string FormCityName { get; set; }
        public string ToCityName { get; set; }
        public TimeSpan When { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Remark { get; set; }

    }
}
