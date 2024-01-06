using System.ComponentModel.DataAnnotations.Schema;

namespace TOMS.Models.DataModels
{
    [Table("City")]
    public class CityEntity:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }

    }
}
