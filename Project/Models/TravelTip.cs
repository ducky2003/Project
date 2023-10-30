using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    [Table("TravelTips")]
    public class TravelTip
    {
        [Key]
        public int TipID { get; set; }
        public string? TipTitle { get; set; }
        public string? TipContent { get; set; }
        public bool? IsActive { get; set; }
    }
}
