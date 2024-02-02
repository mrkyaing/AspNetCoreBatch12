namespace TOMS.Models.ViewModels
{
    public class SeatPlan
    {
        public SeatPlan(string seatPlan)
        {
            this.SeatNo = seatPlan;
        }
        public SeatPlan(string seatPlan,string status)
        {
            this.SeatNo = seatPlan;
            this.Status = status;
        }
        public string SeatNo { get; set; }
        public string Status { get; set; } 
    }
}
