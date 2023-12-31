
using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("Passenger")]
    public class PassengerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string NRC { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
    }
}
