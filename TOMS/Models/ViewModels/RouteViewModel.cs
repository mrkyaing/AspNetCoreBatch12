using System.ComponentModel.DataAnnotations;

namespace TOMS.Models.ViewModels
{
    public class RouteViewModel
    {
        public string Id { get; set; }
        [Required]
        public string FromCityId { get; set; }////foreign key from City table
        public string  FormCityName { get; set; }
        [Required]
        public string ToCityId { get; set; }////foreign key from City table
        public string ToCityName { get; set; }
        [Required(ErrorMessage ="Please enter time format eg:(HH:MM:SS")]
        public TimeSpan When { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public string? Remark { get; set; }
        [Required]
        public string BusLineId { get; set; }//foreign key from BusLine table
        public string Owner { get; set; }
    }
}
