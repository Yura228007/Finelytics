using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Finelytics.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

        [StringLength(50)]
        [DisplayName("Nickname")]
        public string Nickname { get; set; }
    }
}
