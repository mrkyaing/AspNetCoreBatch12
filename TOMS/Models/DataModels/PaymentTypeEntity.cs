using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("PaymentType")]
    public class PaymentTypeEntity:BaseEntity
    {
        public string PaymentType { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
    }
}
