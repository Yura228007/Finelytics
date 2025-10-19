using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finelytics.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Plan ID")]
        public int PlanId { get; set; }

        [Required]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [DisplayName("Planned Amount")]
        [DataType(DataType.Currency)]
        public decimal PlannedAmmount { get; set; }

        [StringLength(255)]
        [DisplayName("Comment")]
        public string Comment { get; set; }
    }
}
