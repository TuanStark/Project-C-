using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Cake_shop.Models.EF
{
    [Table("comment")]
    public class Comment : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]  
        
        public long id {  get; set; }
        [Required]  
        public long Users_id {  get; set; }
        [Required]
        public long Products_id { get; set; }
        [StringLength(255)]
        public string content { get; set; }

        [ForeignKey("Products_id")]
        public virtual ProductModel Products { get; set; }
        [ForeignKey("Users_id")]
        public virtual UserModel Users { get; set; }
    }
}