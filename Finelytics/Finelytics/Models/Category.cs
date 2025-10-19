using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finelytics.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Planned Amount")]
        [DataType(DataType.Currency)]
        public decimal PlannedAmmount { get; set; }

        [DisplayName("Is Income Category")]
        public bool IsIncome { get; set; }
    }
}
