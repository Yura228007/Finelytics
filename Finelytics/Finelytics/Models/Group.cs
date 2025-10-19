using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finelytics.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Group Name")]
        public string Name { get; set; }

        [DisplayName("Planned Amount")]
        [DataType(DataType.Currency)]
        public decimal PlannedAmmount { get; set; }
    }
}
