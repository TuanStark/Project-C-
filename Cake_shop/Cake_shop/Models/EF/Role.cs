using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Cake_shop.Models.EF
{
    [Table("role")]
    public class Role : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long id {  get; set; }
        [StringLength(255)]
        public string name {  get; set; }
        [StringLength(255)]
        public string code {  get; set; }

        public ICollection<UserModel> Users { get; set; }
        public ICollection<AminModel> Admins { get; set; }
    }
}