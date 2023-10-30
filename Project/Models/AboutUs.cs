using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    [Table("AboutUs")]
    public class AboutUs
    {
        [Key] 
        public string? AboutContent { get; set; }
        public string? AboutImg { get; set; }
        public bool? IsActive { get; set; }
        public string? AboutTitle { get; set; }
    }
}
