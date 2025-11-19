using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finelytics.Models
{
    public class GroupPlans
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Plan ID")]
        public int PlanId { get; set; }

        [Required]
        [DisplayName("Group ID")]
        public int GroupId { get; set; }
    }
}
