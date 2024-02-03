namespace TOMS.Models.ViewModels
{
    public class SeatPlan
    {
        public SeatPlan(string seatNo)
        {
            this.SeatNo = seatNo;
        }
        public SeatPlan(string seatNo, string status)
        {
            this.SeatNo = seatNo;
            this.Status = status;
        }
        public string SeatNo { get; set; }
        public string Status { get; set; } 
    }
}
