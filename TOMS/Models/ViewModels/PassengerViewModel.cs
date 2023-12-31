using System.Diagnostics;

namespace TOMS.Models.ViewModels
{
    public class PassengerViewModel
    {
        public string Id { get; set; }//for update,delete process 
        public string Name { get; set; }
        public string NRC { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
    }
}
