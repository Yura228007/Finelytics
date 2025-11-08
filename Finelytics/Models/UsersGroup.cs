using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finelytics.Models
{
    public class UsersGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Group ID")]
        public int GroupId { get; set; }
    }
}
