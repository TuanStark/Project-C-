using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cake_shop.Models.EF
{
    [Table("slides")]
    public class Slides : BaseModel
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long id {  get; set; }
        [StringLength(255)]
    public string img {  get; set; } 
    
    }
}