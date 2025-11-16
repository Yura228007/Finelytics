using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finelytics.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Group Name")]
        public string Name { get; set; }

        //[DisplayName("Planned Amount")]
        //[DataType(DataType.Currency)]
        //public decimal PlannedAmmount { get; set; } // вот это убираем потому что у группы план который вколючает в себя PlannedAmmount
    }
}
