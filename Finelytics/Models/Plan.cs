using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finelytics.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Period")]
        public DateTime Period { get; set; }

        [DisplayName("Planned Amount")]
        [DataType(DataType.Currency)]
        public decimal PlannedAmmount { get; set; }
    }
}
