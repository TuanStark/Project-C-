using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.EF
{
    [Table("user")]
    public class UserModel : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        [StringLength(100)]
        public string fullname { get; set; }
        [StringLength(100)]
        public string email {  get; set; }
        [StringLength(100)]
        public string password { get; set; }
        [StringLength(12)]
        public string phone { get; set; }
        [StringLength(100)]
        public string address { get; set; }
        public int? status { get; set; }
        [Required]
        public long Roles_id { get; set; }
        [ForeignKey("Roles_id")]
        public ICollection<Role> roles { get; set; }

        public ICollection<Comment> comments { get; set; }
        public ICollection<OdersModel> oders { get; set; }

    }
}