using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finelytics.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]        
        public string Name { get; set; }

        [Required]
        [DisplayName("StartDate")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("EndDate")]
        public DateTime EndDate { get; set; }
        
        [DisplayName("Planned Amount")]
        [DataType(DataType.Currency)]
        public decimal PlannedAmmount { get; set; }

        [DisplayName("Enable")]
        public bool IsEnable {get; set;}
    }
}
