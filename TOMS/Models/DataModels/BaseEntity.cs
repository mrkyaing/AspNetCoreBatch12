using System.ComponentModel.DataAnnotations;
using TOMS.Services.Utilities;
namespace TOMS.Models.DataModels
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public string IpAddress { get; set; }=NetworkHelper.GetLocalIPAddress();//getting the local ip for tracting
    }
}
