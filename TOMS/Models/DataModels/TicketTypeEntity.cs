using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("TicketType")]
    public class TicketTypeEntity:BaseEntity
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
