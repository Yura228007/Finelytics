using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finelytics.Models
{
    public class UserPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Plan ID")]
        public int PlanId { get; set; }
    }
}
