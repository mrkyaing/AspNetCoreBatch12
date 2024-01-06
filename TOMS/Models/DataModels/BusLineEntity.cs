using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("BusLine")]
    public class BusLineEntity:BaseEntity
    {
        public string No { get; set; }
        public string Owner { get; set; }
        public string Driver1 { get; set; }
        public string PhoneOfDriver1 { get; set; }
        public string Helper1 { get; set; }
        public string PhoneOfHelper1 { get; set; }
        public string Driver2 { get; set; }
        public string PhoneOfDriver2 { get; set; }
        public string Helper2 { get; set; }
        public string PhoneOfHelper2 { get; set; }
        public int NumberOfSeat { get; set; }
        public string Type { get; set; }
    }
}
