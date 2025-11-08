using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finelytics.Models
{
    public class PlanCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Plan ID")]
        public int PlanId { get; set; }

        [Required]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }
    }
}
