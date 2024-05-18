
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cake_shop.Models.EF
{
    [Table("admin")]
    public class AminModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id {  get; set; }
        [Required]
        public long Roles_id { get; set; }
        [StringLength(50)] 
        public string username {  get; set; }
        [StringLength(50)]
        public string email { get; set; }
        [StringLength(50)]
        public string password { get; set; }
        [ForeignKey("Roles_id")]
        public virtual Role Roles { get; set; }
    }
}