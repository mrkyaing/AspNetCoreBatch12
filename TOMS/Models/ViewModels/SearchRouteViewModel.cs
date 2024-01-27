namespace TOMS.Models.ViewModels
{
    public class SearchRouteViewModel
    {
        public string? BusLineType { get; set; }
        public  string?  PassengerType { get; set; }
        public string FromCityId { get; set; }
        public string  FromCityName { get; set; }
        public string ToCityId { get; set; }
        public string ToCityName { get; set; }
        public DateTime DepaturedDate { get; set; }
    }
}
