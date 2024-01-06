using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("Route")]
    public class RouteEntity:BaseEntity
    {
        public string FromCityId { get; set; }////foreign key from City table
        public string ToCityId { get; set; }////foreign key from City table
        public TimeSpan When { get; set; }
        public decimal UnitPrice { get; set; }
        public string? Remark { get; set; }
        public string  BusLineId { get; set; }//foreign key from BusLine table
    }
}
